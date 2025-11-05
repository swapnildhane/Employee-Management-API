using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Employee>> GetAll() => _repo.GetAllAsync();
        public Task<Employee?> Get(int id) => _repo.GetByIdAsync(id);
        public Task<Employee> Create(Employee emp) => _repo.AddAsync(emp);
        public Task<Employee> Update(Employee emp) => _repo.UpdateAsync(emp);
        public Task<bool> Delete(int id) => _repo.DeleteAsync(id);
    }
}
