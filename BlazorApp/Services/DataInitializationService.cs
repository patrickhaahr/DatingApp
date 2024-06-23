using BlazorApp.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class DataInitializationService
    {
        private readonly DatingAppDbContext _context;

        public DataInitializationService(DatingAppDbContext context)
        {
            _context = context;
        }

        public async Task EnsureDataAsync()
        {
            if (!_context.Accounts.Any() || !_context.Profiles.Any())
            {
                RunBatchFile();
            }
        }

        private void RunBatchFile()
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("DataInitializationService.bat")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            Process process = Process.Start(processInfo);
            process.WaitForExit();
        }
    }
}
