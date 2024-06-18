using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class City
    {
        [Key]
        public int ZipCode { get; set; }
        public string CityName { get; set; }
        
    }
}
