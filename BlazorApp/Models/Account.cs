using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp.Models.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long.")]
        [Column(TypeName = "nvarchar(50)")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long.")]
        [Column(TypeName = "nvarchar(50)")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "You must specify a birth date.")]
        [DataType(DataType.Date)]
        [BirthDateValidation(ErrorMessage = "User must be 18 years or older to create an account.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Username must be at least 2 characters long.")]
        [Column(TypeName = "nvarchar(50)")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [EmailValidation]
        [MaxLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [MinLength(2, ErrorMessage = "Email must be at least 2 characters long.")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [MaxLength(50, ErrorMessage = "Password cannot be longer than 50 characters.")]
        [PasswordValidation]
        [Column(TypeName = "nvarchar(50)")]
        public string? Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        [DefaultValue("User")]
        [MaxLength(20)]
        [HiddenInput(DisplayValue = false)]
        [Column(TypeName = "nvarchar(20)")]
        public string Role { get; set; } = "User";

        public List<Like> SentLikes { get; set; } = new List<Like>();
        public Profile Profile { get; set; }
        public List<Message> SentMessages { get; set; } = new List<Message>();
    }
}
