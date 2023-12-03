// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - MustNotBeGreaterThanAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Mvc.Validation;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MustNotBeGreaterThanAttribute(string otherPropertyName, string errorMessage, string prefix)
    : ValidationAttribute(errorMessage), IClientModelValidator
{
    private string _otherPropertyDisplayName;
    public MustNotBeGreaterThanAttribute(string otherPropertyName, string prefix = "")
        : this(otherPropertyName, "{0} must not be greater than {1}", prefix) { }

    public override string FormatErrorMessage(string name) 
        => string.Format(ErrorMessageString, name, _otherPropertyDisplayName);

    internal void SetOtherPropertyName(PropertyInfo otherPropertyInfo)
    {
        _otherPropertyDisplayName = 
            otherPropertyInfo.GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name
            ?? otherPropertyInfo.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault()?.DisplayName
            ?? otherPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetProperty(otherPropertyName);
        if (otherPropertyInfo == null)
        {
            return new ValidationResult("Unable to validate property. Please contact support");
        }
        SetOtherPropertyName(otherPropertyInfo);
        if (!int.TryParse(value.ToString(), out int toValidate))
        {
            return new ValidationResult($"{validationContext.DisplayName} must be numeric.");
        }
        var otherPropObjectValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (otherPropObjectValue == null || !int.TryParse(otherPropObjectValue.ToString(), 
                out var otherValue))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return toValidate > otherValue 
            ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) 
            : ValidationResult.Success;
    }


    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName = context.ModelMetadata.GetDisplayName();
        var propertyInfo = context.ModelMetadata.ContainerType.GetProperty(otherPropertyName);
        SetOtherPropertyName(propertyInfo);
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-notgreaterthan", errorMessage);
        context.Attributes.Add("data-val-notgreaterthan-otherpropertyname", otherPropertyName);
        context.Attributes.Add("data-val-notgreaterthan-prefix", prefix);

    }
}