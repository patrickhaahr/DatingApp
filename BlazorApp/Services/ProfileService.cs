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
        public async Task<List<Profile>> GetProfilesWithCitiesAsync()
        {
            return await _context.Profiles.Include(p => p.City).Where(p => !p.IsDeleted).ToListAsync();
        }
        public async Task AddProfileAsync(Profile profile)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Profiles ON");
                    _context.Profiles.Add(profile);
                    await _context.SaveChangesAsync();
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Profiles OFF");
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
        public async Task UpdateProfileAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
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
                return await _context.Profiles.Include(p => p.City).FirstOrDefaultAsync(p => p.AccountId == account.AccountId);
            }

            return null;
        }

        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            return await _context.Profiles.FindAsync(profileId);
        }
        public async Task<Profile> GetProfileByAccountIdAsync(int accountId)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.AccountId == accountId);
        }


        public async Task<List<Profile>> GetProfilesAsync()
        {
            var account = await _authHelperService.GetAuthenticatedAccountAsync();
            if (account != null)
            {
                var currentUserProfile = await GetProfileByAccountIdAsync(account.AccountId);
                var likedProfiles = await _context.Likes
                    .Where(l => l.SenderId == account.AccountId && l.Status != -1)
                    .Select(l => l.ReceiverId)
                    .ToListAsync();

                var profiles = await _context.Profiles
                    .Include(p => p.Account)
                    .Where(p => p.AccountId != account.AccountId && !likedProfiles.Contains(p.ProfileId))
                    .ToListAsync();

                if (currentUserProfile != null)
                {
                    profiles = profiles.Where(p =>
                        (!currentUserProfile.PreferredMinHeight.HasValue || p.Height >= currentUserProfile.PreferredMinHeight) &&
                        (!currentUserProfile.PreferredMaxHeight.HasValue || p.Height <= currentUserProfile.PreferredMaxHeight) &&
                        (!currentUserProfile.PreferredMinWeight.HasValue || p.Weight >= currentUserProfile.PreferredMinWeight) &&
                        (!currentUserProfile.PreferredMaxWeight.HasValue || p.Weight <= currentUserProfile.PreferredMaxWeight) &&
                        (!currentUserProfile.PreferredMinAge.HasValue || p.Age >= currentUserProfile.PreferredMinAge) &&
                        (!currentUserProfile.PreferredMaxAge.HasValue || p.Age <= currentUserProfile.PreferredMaxAge) &&
                        (!currentUserProfile.PreferredGender.HasValue || p.Gender == currentUserProfile.PreferredGender)
                    ).ToList();
                }

                // Shuffle the profiles list
                var random = new Random();
                profiles = profiles.OrderBy(p => random.Next()).ToList();

                return profiles;
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

                var mutualLike = await _context.Likes.FirstOrDefaultAsync(l => l.SenderId == profileId && l.ReceiverId == account.AccountId && l.Status == 2);
                if (mutualLike != null)
                {
                    mutualLike.Status = 1;
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
