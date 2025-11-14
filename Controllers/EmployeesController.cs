using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var emp = await _service.Get(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.Create(employee);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Updated = await _service.Update(employee);
               return Ok(Updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _service.Delete(id));
    }
}
