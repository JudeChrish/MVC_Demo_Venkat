using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo_25July2017.Models;

namespace MvcDemo_25July2017.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeContext empContext = new EmployeeContext();
            List<DepartmentModel> Departments = empContext.Departments.ToList();
            return View(Departments);
        }
    }
}