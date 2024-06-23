using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlazorApp.Models
{
    public class Profile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int AccountId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        [Required(ErrorMessage = "Bio is required.")]
        [MaxLength(1000, ErrorMessage = "First name cannot be longer than 1000 characters.")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long.")]
        [Column(TypeName = "nvarchar(1000)")]
        public string Bio { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public DateTime BirthDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string? Pic { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        public bool Gender { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        [Required]
        [ForeignKey("City")]
        public int ZipCode { get; set; }
        
        public City City { get; set; }
        public List<Like> ReceivedLikes { get; set; } = new List<Like>();
        public List<Message> ReceivedMessages { get; set; } = new List<Message>();

        [NotMapped]
        public string GenderDisplay => Gender ? "Male" : "Female"; // Computed property for gender

        [NotMapped]
        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0); // Computed property for age

        [NotMapped]
        public int? PreferredMinHeight { get; set; }
        [NotMapped]
        public int? PreferredMaxHeight { get; set; }
        [NotMapped]
        public int? PreferredMinWeight { get; set; }
        [NotMapped]
        public int? PreferredMaxWeight { get; set; }
        [NotMapped]
        public int? PreferredMinAge { get; set; }
        [NotMapped]
        public int? PreferredMaxAge { get; set; }
        [NotMapped]
        public bool? PreferredGender { get; set; }
        [NotMapped]
        public bool PreferredAllGenders { get; set; }
    }
}