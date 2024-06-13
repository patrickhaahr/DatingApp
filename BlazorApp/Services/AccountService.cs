using BlazorApp.Models;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class AccountService
    {
        private readonly DatingAppDbContext _context;

        public AccountService(DatingAppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByUserNameAsync(string userName)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.UserName == userName);
        }
    }
}
