using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVueJs.Models
{
    public class Employee
    {
        public int EmployeeID { set; get; }
        public string EmployeeName { set; get; }
        public string Department { set; get; }
        public DateTime DateOfJoining { set; get; }
        public string PhotoFileName { set; get; }

    }
}
