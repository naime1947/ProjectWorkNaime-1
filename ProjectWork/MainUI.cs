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
        
        public MainUI()
        {
            InitializeComponent();
            designationList = new List<Designation>();

        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployeeUI anAddEmployeeUi = new AddEmployeeUI();
            anAddEmployeeUi.Show();
        }

        private void addDesignationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddViewDesignationUI addViewDesignationUi = new AddViewDesignationUI(designationList);
            addViewDesignationUi.Show();
        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromotionUI promotionUi = new PromotionUI();
            promotionUi.Show();
        }

        private void viewMonthlySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMonthlySalaryUI viewMonthlySalaryUi = new ViewMonthlySalaryUI();
            viewMonthlySalaryUi.Show();
        }

        private void resignationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeResignationUI employeeResignationUi = new EmployeeResignationUI();
            employeeResignationUi.Show();
        }
    }
}
