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
    public partial class PromotionUI : Form
    {
        private List<Employee> employeeList;
        private List<Designation> designationList;

        public PromotionUI()
        {
            InitializeComponent();
        }

        public PromotionUI(List<Employee> employeeList, List<Designation> designationList):this()
        {
            this.employeeList = employeeList;
            this.designationList = designationList;
        }

        private void PromotionUI_Load(object sender, EventArgs e)
        {
            comboBoxEmployeeCode.DataSource = employeeList;
            comboBoxEmployeeCode.DisplayMember = "Code";

            comboBoxNeDesigList.DataSource = designationList;
            comboBoxNeDesigList.DisplayMember = "Title";
        }

       

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindCodeInEmployee();
        }

        private void FindCodeInEmployee()
        {
            string code = comboBoxEmployeeCode.Text;
            bool flag = true;
            foreach (var employee in employeeList)
            {
                if (employee.Code == code)
                {
                    Employee selectedEmployee = employee;
                    textBoxName.Text = employee.Name;
                    textBoxEmail.Text = employee.Email;
                    textBoxCurrentDesignation.Text = employee.Designation.Title;
                    flag = false;
                    break;

                }
            }
            if (flag) { MessageBox.Show("No Employe records found"); }
        }
    }
}
