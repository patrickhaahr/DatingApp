using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
    }
}
