using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class ProfileService
    {
        private readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProfileAsync(Profile profile)
        {
            await _httpClient.PostAsJsonAsync("api/profile", profile);
        }
    }
}
