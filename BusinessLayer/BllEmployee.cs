using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BllEmployee:IBllEmployee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
