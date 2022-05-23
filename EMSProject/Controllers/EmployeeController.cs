using EMSProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSProject.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        public EMSDBContext dbContext;
        public EmployeeController(EMSDBContext context)
        {
           this. dbContext = context;
        }
        public IActionResult Index()
        {
            var emps = dbContext.Employees.ToList();

            return View(emps);
        }
        public IActionResult Create()
        {
           

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees model)
        {
            dbContext.Employees.Add(model);
            dbContext.SaveChanges();
            TempData["error"] = "Employee Create succefully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            dbContext.Employees.Remove(emp);
            dbContext.SaveChanges();
            TempData["error"] = "Employee Deleted succefully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e=>e.Id==Id);
            var result = new Employees()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Mobile = emp.Mobile,

                Image = emp.Image,
                IsActive = emp.IsActive
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
             Employees db = new Employees()
            {
                Id=employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Mobile = employee.Mobile,
                Image = employee.Image,
                IsActive = employee.IsActive
};
 dbContext.Employees.Update(db);
            dbContext.SaveChanges();
            TempData["error"] = "Employee updated succefully";
            return RedirectToAction("Index");
    }
    public IActionResult Details(int Id)
        {
            var emps = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            return View(emps);
        }

    }
}
