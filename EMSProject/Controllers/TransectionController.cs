using EMSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSProject.Controllers
{
    public class TransectionController : Controller
    {
        public EMSDBContext dbContext;
        public TransectionController(EMSDBContext context)
        {
            dbContext = context;
        }
        public IActionResult GetAllEmployee()
        {
            var emp = dbContext.Transections.ToList();
            return View(emp);
        }
        [HttpPost]
        public IActionResult Create(Transection model)
        {
            dbContext.Transections.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var emp = dbContext.Transections.SingleOrDefault(e => e.Id == Id);
            dbContext.Transections.Remove(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var emp = dbContext.Transections.Find(Id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Transection employee)
        {
            var emps = dbContext.Transections.SingleOrDefault(e => e.Id == employee.Id);
            Transection db = new Transection();
            {
                db.Name = emps.Name;
                db.Position = emps.Position;
                db.Salary = emps.Salary;




            };

            dbContext.Transections.Update(db);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
            var emps = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            return View(emps);
        }
    }
}
