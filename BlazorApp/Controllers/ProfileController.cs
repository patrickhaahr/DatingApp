using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly DatingAppDbContext _context;

        public ProfileController(DatingAppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
            return Ok(profile);
        }
    }
}
