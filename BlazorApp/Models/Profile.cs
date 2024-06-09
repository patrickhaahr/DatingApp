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
        public int AccountId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public string Pic { get; set; }
        public string NickName { get; set; }
        public bool Gender { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public List<Like> ReceivedLikes { get; set; } = new List<Like>();
    }
}
