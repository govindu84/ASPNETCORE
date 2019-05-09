using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCore.Model;

namespace WebApplication4.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IRepository<Employee> _context;

        public EmployeesController(IRepository<Employee> context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            ViewBag.Title = "My Strength";
            return View(_context.GetAllEmployees());
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            ViewBag.Title = "Employee Detail";
            var employee = _context.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
                return View(_context.GetEmployee(id));
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit([Bind("Id,Name,EmpCode,Email,Position")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id != 0)
                {
                    employee = _context.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    employee = _context.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }



        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {

            var employee = _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }
       

    }
}
