// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - MustBeGreaterThanZeroAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Mvc.Validation;

public class MustBeGreaterThanZeroAttribute(string errorMessage)
    : ValidationAttribute(errorMessage), IClientModelValidator
{
    public MustBeGreaterThanZeroAttribute() : this("{0} must be greater than 0") { }

    public override string FormatErrorMessage(string name) 
        => string.Format(ErrorMessageString, name);

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (!int.TryParse(value.ToString(), out int result))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return result > 0 ? ValidationResult.Success : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName = 
            context.ModelMetadata.DisplayName ?? context.ModelMetadata.PropertyName;
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-greaterthanzero", errorMessage);
    }
}
