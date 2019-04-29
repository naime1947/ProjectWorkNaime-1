using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllClasses;

namespace ProjectWork
{
    public partial class ViewMonthlySalaryUI : Form
    {
        private List<Employee> employeeList;

        public ViewMonthlySalaryUI()
        {
            InitializeComponent();
        }

        public ViewMonthlySalaryUI(List<Employee> employeeList) : this()
        {
            this.employeeList = employeeList;
        }

        private void ViewMonthlySalaryUI_Load(object sender, EventArgs e)
        {
            comboBoxYear.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            comboBoxYear.SelectedItem = DateTime.Now.Year;

            comboBoxMonth.DataSource = CultureInfo.InvariantCulture.DateTimeFormat
                                                     .MonthNames.Take(12).ToList();
            comboBoxMonth.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat
                                                    .MonthNames[DateTime.Now.AddMonths(-1).Month - 1];
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            listViewShowDetails.Items.Clear();
            string year = comboBoxYear.SelectedItem.ToString();
            string month = comboBoxMonth.SelectedItem.ToString();
            DateTime yearMonth = DateTime.Parse(year + "/" + month);
            
            int counter = 0;
            double totalAmount = 0;
            ListViewItem item;

            foreach (var employee in employeeList)
            {
                foreach (var careerHisory in employee.careerHistorieList)
                {
                    if (careerHisory.StartDate<yearMonth && careerHisory.EndDate == null)
                    {
                        if (DateTime.Today >= yearMonth)
                        {
                            item = new ListViewItem((++counter).ToString());
                            item.SubItems.Add(employee.Name);
                            item.SubItems.Add(employee.Code);
                            item.SubItems.Add(careerHisory.Designation.Total.ToString());
                            listViewShowDetails.Items.Add(item);
                            totalAmount += careerHisory.Designation.Total;
                        }

                    }
                    else if (careerHisory.StartDate<=yearMonth && careerHisory.EndDate>=yearMonth)
                    {
                        item = new ListViewItem((++counter).ToString());
                        item.SubItems.Add(employee.Name);
                        item.SubItems.Add(employee.Code);
                        item.SubItems.Add(careerHisory.Designation.Total.ToString());
                        listViewShowDetails.Items.Add(item);
                        totalAmount += careerHisory.Designation.Total;

                    }
                }
                
            }

            textBoxTotal.Text = totalAmount.ToString();

        }
        
    }
}
