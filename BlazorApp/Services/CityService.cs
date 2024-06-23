using BlazorApp.Data;
using BlazorApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CityService
    {
        private readonly DatingAppDbContext _context;
        private readonly DataInitializationService _dataInitializationService;

        public CityService(DatingAppDbContext context, DataInitializationService dataInitializationService)
        {
            _context = context;
            _dataInitializationService = dataInitializationService;
        }

        public List<City> GetCityAsync()
        {
            return _context.Cities.Select(c => c).ToList();
        }

        public async Task EnsureCitiesDataAsync()
        {
            if (!_context.Cities.Any())
            {
                RunBatchFile();
                await _dataInitializationService.EnsureDataAsync();
            }
        }

        private void RunBatchFile()
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("city.cmd")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            Process process = Process.Start(processInfo);
            process.WaitForExit();
        }
    }
}
