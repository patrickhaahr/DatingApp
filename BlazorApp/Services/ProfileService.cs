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
        private readonly AuthHelperService _authHelperService;

        public ProfileService(DatingAppDbContext context, AuthHelperService authHelperService)
        {
            _context = context;
            _authHelperService = authHelperService;
        }

        public async Task SaveImageToDatabase(string base64Image)
        {
            var account = await _authHelperService.GetAuthenticatedAccountAsync();
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

        public async Task<Profile> GetProfileAsync()
        {
            var account = await _authHelperService.GetAuthenticatedAccountAsync();
            if (account != null)
            {
                return await _context.Profiles.FirstOrDefaultAsync(p => p.AccountId == account.AccountId);
            }

            return null;
        }

        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            return await _context.Profiles.FindAsync(profileId);
        }

        public async Task<List<Profile>> GetProfilesAsync()
        {
            var account = await _authHelperService.GetAuthenticatedAccountAsync();
            if (account != null)
            {
                var likedProfiles = await _context.Likes
                    .Where(l => l.SenderId == account.AccountId && l.Status != -1) // Exclude profiles with status other than -1
                    .Select(l => l.ReceiverId)
                    .ToListAsync();

                return await _context.Profiles
                    .Include(p => p.Account)
                    .Where(p => p.AccountId != account.AccountId && !likedProfiles.Contains(p.ProfileId)) // Exclude the logged-in user's profile
                    .ToListAsync();
            }

            return new List<Profile>();
        }

        public async Task LikeProfileAsync(int profileId)
        {
            var account = await _authHelperService.GetAuthenticatedAccountAsync();
            if (account != null)
            {
                var existingLike = await _context.Likes
                    .FirstOrDefaultAsync(l => l.SenderId == account.AccountId && l.ReceiverId == profileId);

                if (existingLike == null)
                {
                    var like = new Like
                    {
                        SenderId = account.AccountId,
                        ReceiverId = profileId,
                        Status = 1
                    };

                    var mutualLike = await _context.Likes
                        .FirstOrDefaultAsync(l => l.SenderId == profileId && l.ReceiverId == account.AccountId && l.Status == 1);

                    if (mutualLike != null)
                    {
                        like.Status = 2;
                        mutualLike.Status = 2;
                    }

                    _context.Likes.Add(like);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DislikeProfileAsync(int profileId)
        {
            var account = await _authHelperService.GetAuthenticatedAccountAsync();
            if (account != null)
            {
                var like = await _context.Likes.FirstOrDefaultAsync(l => l.SenderId == account.AccountId && l.ReceiverId == profileId);
                if (like == null)
                {
                    like = new Like
                    {
                        SenderId = account.AccountId,
                        ReceiverId = profileId,
                        Status = 0
                    };

                    _context.Likes.Add(like);
                }
                else
                {
                    like.Status = 0;
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
