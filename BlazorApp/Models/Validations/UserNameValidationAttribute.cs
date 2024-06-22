using System.ComponentModel.DataAnnotations;
using System.Linq;
using BlazorApp.Data;

namespace BlazorApp.Models.Validations
{
    public class UserNameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userName = value as string;

            var dbContext = (DatingAppDbContext)validationContext.GetService(typeof(DatingAppDbContext));
            if (dbContext.Accounts.Any(a => a.UserName == userName))
            {
                return new ValidationResult("Username already exists.");
            }

            return ValidationResult.Success;
        }
    }
}