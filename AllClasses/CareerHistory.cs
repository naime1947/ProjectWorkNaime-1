using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    public class CareerHistory
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Designation Designation { get; set; }
        public double TotalSalary
        {
            get
            {
                return Designation.Total;
            }
        }
    }
}
