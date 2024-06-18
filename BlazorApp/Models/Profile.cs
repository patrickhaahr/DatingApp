using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int AccountId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

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
        public List<Like> ReceivedLikes { get; set; } = new List<Like>();
        public List<Message> ReceivedMessages { get; set; } = new List<Message>();

        [NotMapped]
        public string GenderDisplay => Gender ? "Male" : "Female"; // Computed property for gender

        [NotMapped]
        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0); // Computed property for age
    }
}
