using BlazorApp.Models;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class ProfileService
    {
        private readonly DatingAppDbContext _context;

        public ProfileService(DatingAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Profile>> GetProfilesAsync()
        {
            return await _context.Profiles.ToListAsync();
        }
    }
}
