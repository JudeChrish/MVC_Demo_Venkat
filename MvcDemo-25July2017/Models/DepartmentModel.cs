using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcDemo_25July2017.Models
{
    [Table("tbl_Department")]
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}