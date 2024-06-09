using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public int AccountId { get; set; }
        public int CityId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
