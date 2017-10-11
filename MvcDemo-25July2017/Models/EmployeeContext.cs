using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcDemo_25July2017.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
    }
}