using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is Required")]
        [StringLength(50,ErrorMessage ="Name cannot Exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Departnment Id is Required")]
        [Range(1,int.MaxValue, ErrorMessage = "Department must be valid")]
        public string Department { get; set; }
        [Required]
        [Range(10000,100000,ErrorMessage ="Salary must be between 10k to 1Lac")]
        public decimal Salary { get; set; }
    }
}
