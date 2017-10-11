using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBllEmployee
    {
        int EmpId { get; set; }
        string Designation { get; set; }
        int DepartmentId { get; set; }
    }
}
