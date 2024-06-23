using BlazorApp.Data;
using BlazorApp.Models;
using System.Diagnostics;

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

        public async Task EnsureCitiesDataAsync()
        {
            if (!_context.Cities.Any())
            {
                RunBatchFile();
            }
        }

        private void RunBatchFile()
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("city.cmd")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process process = Process.Start(processInfo);
            process.WaitForExit();
        }
    }
}
