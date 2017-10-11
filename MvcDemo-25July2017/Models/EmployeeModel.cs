using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcDemo_25July2017.Models
{
    [Table("tbl_Employee")]
    public class EmployeeModel
    {        
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}