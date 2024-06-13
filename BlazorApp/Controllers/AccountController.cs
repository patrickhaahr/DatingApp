using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DatingAppDbContext _context;

        public AccountController(DatingAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Account>> GetAccountByEmail(string email)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }
    }
}
