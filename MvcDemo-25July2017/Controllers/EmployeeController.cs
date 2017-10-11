using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo_25July2017.Models;
using System.Collections;
using BusinessLayer;

namespace MvcDemo_25July2017.Controllers
{
    public class EmployeeController : Controller
    {
        //GET ALL EMPLOYEES
        public ActionResult Index(int DepartmentId)
        {
            EmployeeContext empContextAll = new EmployeeContext();
            List<EmployeeModel> employees = empContextAll.Employee.Where(e => e.DepartmentId == DepartmentId).ToList();
            return View(employees);
        }
        // GET: Employee
        public ActionResult Details(int id)
        {
            EmployeeContext empContext = new EmployeeContext();
            EmployeeModel emp = empContext.Employee.FirstOrDefault(e => e.EmpId == id);
            return View(emp);
        }

        //load all employees using business loging layer
        public ActionResult GetEmployee()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<BllEmployee> allemployees = employeeBusinessLayer.Employees.ToList();
            return View(allemployees);
        }

        //handle the create event of GetEmployee
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            BllEmployee bllEmployee = new BllEmployee();
            TryUpdateModel(bllEmployee);

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.CreateEmployee(bllEmployee);
                return RedirectToAction("GetEmployee");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Selected_Employee_Get(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            BllEmployee bllEmployee = employeeBusinessLayer.Employees.Single(s => s.EmpId == id);
            return View(bllEmployee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Selected_Employee_Post(int EmpId)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            BllEmployee bllEmployee = employeeBusinessLayer.Employees.Single(s => s.EmpId == EmpId);
            TryUpdateModel<IBllEmployee>(bllEmployee);
            if (ModelState.IsValid)
            {
                employeeBusinessLayer.UpdateEmployee(bllEmployee);
                return RedirectToAction("GetEmployee");
            }
            return View();
        }

        ////[HttpPost]
        ////[ActionName("Edit")]
        ////public ActionResult Edit_Selected_Employee_Post(int EmpId)
        ////{
        ////    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        ////    BllEmployee bllEmployee = employeeBusinessLayer.Employees.Single(s => s.EmpId == EmpId);
        ////    TryUpdateModel(bllEmployee, null, null, new string[] { "Name" });
        ////    if (ModelState.IsValid)
        ////    {

        ////        employeeBusinessLayer.UpdateEmployee(bllEmployee);
        ////        return RedirectToAction("GetEmployee");
        ////    }
        ////    return View();
        ////}

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id); 
            return RedirectToAction("GetEmployee");
        }
    }
}