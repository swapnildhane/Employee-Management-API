using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Employees.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await _context.Employees.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok("Employee Added");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee emp)
        {
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            return Ok("Employee Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok("Employee Deleted");
        }
    }
}
