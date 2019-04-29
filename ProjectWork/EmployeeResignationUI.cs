using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllClasses;

namespace ProjectWork
{
    public partial class EmployeeResignationUI : Form
    {
        private List<Employee> employeeList;
        private List<Designation> designationList;

        public EmployeeResignationUI()
        {
            InitializeComponent();
        }

        public EmployeeResignationUI(List<Employee> employeeList, List<Designation> designationList):this()
        {
            this.employeeList = employeeList;
            this.designationList = designationList;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Employee employee = FindEmployee();
            if (employee != null && employee.CurrentDesignation!=null)
            {
                textBoxName.Text = employee.Name;
                textBoxEmail.Text = employee.Email;
                textBoxCurrentDesignation.Text = employee.CurrentDesignation.Title;
                btnResign.Enabled = true;
            }
            else { MessageBox.Show("Rocords Not Found"); btnResign.Enabled = false; }
        }

        private Employee FindEmployee()
        {
            string code = comboBoxEmployeeCode.Text;
            foreach (var employee in employeeList)
            {
                if (employee.Code == code)
                {
                    return employee;
                }
            }
            return null;
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            Employee employee = FindEmployee();
            if (employee != null)
            {
                employee.careerHistorieList[0].EndDate = DateTime.Today;
                employee.IsWorking = false;
            }
            else
            {
                MessageBox.Show("Something Went Wrong");
            }

            MessageBox.Show("Resigned Successfully");
        }

        private void EmployeeResignationUI_Load(object sender, EventArgs e)
        {
            btnResign.Enabled = false;
            comboBoxEmployeeCode.DataSource = employeeList;
            comboBoxEmployeeCode.DisplayMember = "Code"; 
        }

        //List<Employee> GetListOfAllWorkingEmployee()
        //{
        //    List<Employee> employeeListOnWok = new List<Employee>();
        //    foreach (var employee in employeeList)
        //    {
        //        if (employee.IsWorking)
        //        {
        //            employeeListOnWok.Add(employee);
        //        }
        //    }

        //    return employeeListOnWok;
        //}
    }
}
