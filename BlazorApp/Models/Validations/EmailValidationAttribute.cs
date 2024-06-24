using System.ComponentModel.DataAnnotations;
using System.Linq;
using BlazorApp.Data;

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

            var dbContext = (DatingAppDbContext)validationContext.GetService(typeof(DatingAppDbContext));
            var accountId = (int)validationContext.ObjectType.GetProperty("AccountId").GetValue(validationContext.ObjectInstance, null);

            if (dbContext.Accounts.Any(a => a.Email == email && a.AccountId != accountId))
            {
                return new ValidationResult("Email already exists.");
            }

            return ValidationResult.Success;
        }
    }
}
