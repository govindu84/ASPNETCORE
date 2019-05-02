using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Model;
using WebApplication4.ViewModels;
namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepo;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }

        public IActionResult Index()
        {
            List<Employee> model = _employeeRepo.GetAllEmployees();
            return View(model);
        }
        public IActionResult Details()
        {
            List<Employee> model = _employeeRepo.GetAllEmployees();
            return View("Index",model);
        }
        public IActionResult GetEmployee(int id)
        {
           
            HomeListViewModel objHLVM = new HomeListViewModel()
            {
                employee = _employeeRepo.GetEmployee(id),
                PageTitle = "This is First View",
                Heading = "Welcome to Comp world !"
            };
            return View("List",objHLVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employeeRepo.Add(employee);
                //return RedirectToAction("GetEmployee", new { id = emp.Id });
            }
            return View();
        }

    }
}