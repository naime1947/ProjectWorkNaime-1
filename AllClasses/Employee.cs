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
        public Designation CurrentDesignation
        { get
            {
                foreach (var careerHistory in careerHistorieList)
                {
                    if (careerHistory.EndDate == null)
                    {
                        return careerHistory.Designation;
                    }

                }
                return null;
            }
        }
        public DateTime JoiningDate { get; set; }

        public List<CareerHistory> careerHistorieList { get; set; }
        public Employee()
        {
            careerHistorieList = new List<CareerHistory>();
        }
    }
}
