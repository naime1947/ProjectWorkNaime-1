using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClasses
{
    public class Designation
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public double SalaryBasic { get; set; }
        public double HouseRent { get; set; }
        public double MedicalAmount { get; set; }
        public double Total
        {
            get
            {
                return SalaryBasic + HouseRent + MedicalAmount;
            }
        }
    }
}
