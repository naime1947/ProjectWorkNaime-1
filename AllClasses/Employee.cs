using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    public class Employee
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public Designation Designation { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
