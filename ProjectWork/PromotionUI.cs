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
            Employee employee =  FindEmployee();
            if (employee != null)
            {
                textBoxName.Text = employee.Name;
                textBoxEmail.Text = employee.Email;
                textBoxCurrentDesignation.Text = employee.CurrentDesignation.Title;
            }
            else { MessageBox.Show("Rocords Not Found"); }

            PopulateCareerHistoryListView();
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

        private void PopulateCareerHistoryListView()
        {
            string code = comboBoxEmployeeCode.Text;
            Employee employee = FindEmployee();

            listViewCareerHistory.Items.Clear();
            int counter = 0;

            foreach (var career in employee.careerHistorieList)
            {
                ListViewItem item = new ListViewItem((++counter).ToString());
                item.SubItems.Add(career.StartDate.ToShortDateString());
                if (career.EndDate == null) { item.SubItems.Add(""); } else { item.SubItems.Add(career.EndDate.Value.ToShortDateString()); }
                item.SubItems.Add(career.Designation.Title);
                item.SubItems.Add(career.TotalSalary.ToString());

                listViewCareerHistory.Items.Add(item);
            }
        }

        //private void FindCodeInEmployee()
        //{
        //    string code = comboBoxEmployeeCode.Text;
        //    bool flag = true;
        //    foreach (var employee in employeeList)
        //    {
        //        if (employee.Code == code)
        //        {
        //            Employee selectedEmployee = employee;
        //            textBoxName.Text = employee.Name;
        //            textBoxEmail.Text = employee.Email;
        //            textBoxCurrentDesignation.Text = employee.CurrentDesignation.Title;
        //            flag = false;
        //            break;

        //        }
        //    }
        //    if (flag) { MessageBox.Show("No Employe records found"); }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = FindEmployee();
            employee.careerHistorieList[0].EndDate = DateTime.Today;

            CareerHistory careerHistory = new CareerHistory();
            careerHistory.StartDate = DateTime.Today;
            careerHistory.EndDate = null;
            careerHistory.Designation = (Designation)comboBoxNeDesigList.SelectedItem;
            employee.careerHistorieList.Insert(0, careerHistory);

            PopulateCareerHistoryListView();
        }
    }
}
