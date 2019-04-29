using AllClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectWork
{
    public partial class MainUI : Form
    {
        List<Designation> designationList;
        List<Employee> employeeList;

        
        public MainUI()
        {
            InitializeComponent();
            designationList = new List<Designation>();
            employeeList = new List<Employee>();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployeeUI anAddEmployeeUi = new AddEmployeeUI(employeeList,designationList);
            anAddEmployeeUi.Show();
        }

        private void addDesignationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddViewDesignationUI addViewDesignationUi = new AddViewDesignationUI(designationList);
            addViewDesignationUi.Show();
        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromotionUI promotionUi = new PromotionUI(employeeList,designationList);
            promotionUi.Show();
        }

        private void viewMonthlySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMonthlySalaryUI viewMonthlySalaryUi = new ViewMonthlySalaryUI(employeeList);
            viewMonthlySalaryUi.Show();
        }

        private void resignationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeResignationUI employeeResignationUi = new EmployeeResignationUI(employeeList,designationList);
            employeeResignationUi.Show();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {

        }
    }
}
