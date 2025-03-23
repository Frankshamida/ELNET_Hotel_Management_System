using Microsoft.AspNetCore.Mvc;
using RETRA_HOTEL_SYSTEM_2.Data;
using RETRA_HOTEL_SYSTEM_2.Models; // Add this line
using Microsoft.EntityFrameworkCore; // Add this line for ToListAsync()

namespace RETRA_HOTEL_SYSTEM_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-room")]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Room created successfully!" });
        }

        [HttpGet("get-rooms")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return Ok(rooms);
        }
    }
}
