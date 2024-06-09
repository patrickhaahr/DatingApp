using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Validations
{
    public class BirthDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthDate = (DateTime)value;
            var age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age)) age--;
            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }
    }
}
