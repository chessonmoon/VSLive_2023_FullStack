// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - MustBeGreaterThanZeroAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Web.Validation;
public class MustBeGreaterThanZeroAttribute(string errorMessage)
    : ValidationAttribute(errorMessage), IClientModelValidator
{
    public MustBeGreaterThanZeroAttribute() : this("{0} must be greater than 0") { }

    public override string FormatErrorMessage(string name) => 
        string.Format(ErrorMessageString, name);

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not int intValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return intValue <= 0 
            ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) 
            : ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName = 
            context.ModelMetadata.DisplayName ?? context.ModelMetadata.PropertyName;
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-greaterthanzero", errorMessage);
    }
}