using Microsoft.AspNetCore.Mvc;
using RETRA_HOTEL_SYSTEM_2.Data;
using RETRA_HOTEL_SYSTEM_2.Models; // Add this line
using Microsoft.EntityFrameworkCore; // Add this line for ToListAsync()

namespace RETRA_HOTEL_SYSTEM_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User account created successfully!" });
        }

        [HttpGet("get-employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }
    }
}
