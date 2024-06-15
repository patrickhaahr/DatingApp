using BlazorApp.Models;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ProfileService
    {
        private readonly DatingAppDbContext _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly AccountService _accountService;

        public ProfileService(DatingAppDbContext context, AuthenticationStateProvider authenticationStateProvider, AccountService accountService)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
            _accountService = accountService;
        }

        public async Task SaveImageToDatabase(string base64Image)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var account = await _accountService.GetAccountByUserNameAsync(user.Identity.Name);
                if (account != null)
                {
                    var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.AccountId == account.AccountId);
                    if (profile != null)
                    {
                        profile.Pic = base64Image;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task<Profile> GetProfileAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var account = await _accountService.GetAccountByUserNameAsync(user.Identity.Name);
                if (account != null)
                {
                    return await _context.Profiles.FirstOrDefaultAsync(p => p.AccountId == account.AccountId);
                    
                }
            }

            return null;
        }
        public async Task<List<Profile>> GetProfilesAsync()
        {
            return await _context.Profiles.ToListAsync();
        }
    }
}
