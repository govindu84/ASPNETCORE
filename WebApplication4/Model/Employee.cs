using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name should not be empty")]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name ="Personal Email")]
        public string Email { get; set; }
        public string Department { get; set; }
    }

    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
        Employee Add(Employee emp);
    }


    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com" },
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com" },
                new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "sam@pragimtech.com" },
            };
        }

        public Employee Add(Employee emp)
        {
            emp.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(emp);
            return emp;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
           return _employeeList.FirstOrDefault(x => x.Id == id);
        }
    }

}

