using BlazorApp.Data;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class CityService
    {
        private readonly DatingAppDbContext _context;

        public CityService(DatingAppDbContext context)
        {
            _context = context;
        }

        public List<City> GetCityAsync()
        {
            return _context.Cities.Select(c => c).ToList();
        }
    }
}
