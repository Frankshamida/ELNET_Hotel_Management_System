using Microsoft.AspNetCore.Mvc;
using RETRA_HOTEL_SYSTEM_2.Data;
using RETRA_HOTEL_SYSTEM_2.Models; // Add this line
using Microsoft.EntityFrameworkCore; // Add this line for ToListAsync()

namespace RETRA_HOTEL_SYSTEM_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserAccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-user-accounts")]
        public async Task<IActionResult> GetUserAccounts()
        {
            var userAccounts = await _context.UserAccounts.ToListAsync();
            return Ok(userAccounts);
        }
    }
}
