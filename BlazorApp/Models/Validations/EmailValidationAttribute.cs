using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Validations
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                return new ValidationResult("Email must contain an '@' character.");
            }
            return ValidationResult.Success;
        }
    }
}
