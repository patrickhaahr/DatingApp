using BlazorApp.Models;
using BlazorApp.Models.Enums;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorApp.Services
{
    public class MessageService
    {
        private readonly DatingAppDbContext _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly AccountService _accountService;

        public MessageService(DatingAppDbContext context, AuthenticationStateProvider authenticationStateProvider, AccountService accountService)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
            _accountService = accountService;
        }

        public async Task SendMessageAsync(Message message)
        {
            var receiver = await _context.Profiles.FindAsync(message.ReceiverId);
            if (receiver != null)
            {
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Invalid ReceiverId");
            }
        }

        public async Task<List<Message>> GetMessagesAsync(int userId, int matchProfileId)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => (m.SenderId == userId && m.ReceiverId == matchProfileId) || (m.SenderId == matchProfileId && m.Receiver.AccountId == userId))
                .OrderBy(m => m.SentDate)
                .ToListAsync();
        }

        public async Task<List<Message>> GetAllMessagesAsync(int userId)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.SenderId == userId || m.Receiver.AccountId == userId)
                .OrderBy(m => m.SentDate)
                .ToListAsync();
        }

        public async Task<List<Profile>> GetMatchesAsync(int userId)
        {
            var likedByUser = await _context.Likes
                .Where(l => l.SenderId == userId && l.Status == LikeStatus.Match)
                .Select(l => l.ReceiverId)
                .ToListAsync();

            var likedUser = await _context.Likes
                .Where(l => l.ReceiverId == userId && l.Status == LikeStatus.Match)
                .Select(l => l.SenderId)
                .ToListAsync();

            var matchedUserIds = likedByUser.Union(likedUser).ToList();

            return await _context.Profiles
                .Where(p => matchedUserIds.Contains(p.ProfileId))
                .ToListAsync();
        }
    }
}
