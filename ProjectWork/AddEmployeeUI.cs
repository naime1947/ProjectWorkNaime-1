﻿using System;
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
    public partial class AddEmployeeUI : Form
    {
        private List<Employee> employeeList;
        private List<Designation> designationList;

        public AddEmployeeUI()
        {
            InitializeComponent();
        }
       
        public AddEmployeeUI(List<Employee> employeeList, List<Designation> designationList):this()
        {
            this.employeeList = employeeList;
            this.designationList = designationList;

        }

        private void AddEmployeeUI_Load(object sender, EventArgs e)
        {
            DisbableAndBacktoNewButton();
            PopulateEmployeeListView();

        }

        private void DisbableAndBacktoNewButton()
        {
            textBoxName.Enabled = false;
            textBoxCode.Enabled = false;
            textBoxAddress.Enabled = false;
            textBoxContactNo.Enabled = false;
            textBoxEmail.Enabled = false;
            comboBoxDesignation.Enabled = false;
            btnSave.Enabled = false;
            dateTimePickerJoiningDate.Enabled = false;
            btnCancel.Visible = false;
            btnNew.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (designationList.Count > 0)
            {
                EnableButtonAndFields();
                textBoxCode.Text = Convert.ToString(CodeGenerator());
                PopulateDesignationCombo();
            }
            else
            {
                MessageBox.Show("Please add some designations first");
            }
            
        }

        private int CodeGenerator()
        {
            if (employeeList != null)
            {
                return employeeList.Count + 1;
            }
            else
            {
                return 1;
            }
        }

        private void PopulateDesignationCombo()
        {
            comboBoxDesignation.DataSource = designationList;
            comboBoxDesignation.DisplayMember = "Title";

        }

        private void EnableButtonAndFields()
        {
            textBoxName.Enabled = true;
            textBoxCode.Enabled = true;
            textBoxAddress.Enabled = true;
            textBoxContactNo.Enabled = true;
            textBoxEmail.Enabled = true;
            comboBoxDesignation.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Visible = false;
            dateTimePickerJoiningDate.Enabled = true;
            btnCancel.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FieldsAreEmpty())
            {
                DisbableAndBacktoNewButton();
                

                Employee employee = new Employee()
                {

                    Name = textBoxName.Text,
                    Code = textBoxCode.Text,
                    ContactNo = textBoxContactNo.Text,
                    Email = textBoxEmail.Text,
                    Address = textBoxAddress.Text,
                    JoiningDate = dateTimePickerJoiningDate.Value,
                    
                };

                CareerHistory careerHistory = new CareerHistory();
                careerHistory.StartDate = employee.JoiningDate;
                careerHistory.EndDate = null;
                careerHistory.Designation = (Designation) comboBoxDesignation.SelectedValue;

                employee.careerHistorieList.Insert(0, careerHistory);


                employeeList.Add(employee);
                PopulateEmployeeListView();

            }
        }

        private bool FieldsAreEmpty()
        {
            if (textBoxCode.Text == "") { MessageBox.Show("Please add employee code"); return true; }
            else if (textBoxName.Text == "") { MessageBox.Show("Please add employee name"); return true; }
            else if (textBoxEmail.Text == "") { MessageBox.Show("Please add an email"); return true; }
            else if (!IsEmailValid()) { return true; }
            else if (textBoxContactNo.Text == "") { MessageBox.Show("Please add Contact No"); return true; }
            else if (textBoxAddress.Text == "") { MessageBox.Show("Please add an address"); return true; }
            return false;
        }

        private void PopulateEmployeeListView()
        {
            listViewEmployeList.Items.Clear();
            int counter = 0;
            if (employeeList != null)
            {
                foreach (var employee in employeeList)
                {
                    if (employee.IsWorking)
                    {
                        ListViewItem item = new ListViewItem((++counter).ToString());
                        item.SubItems.Add(employee.Code);
                        item.SubItems.Add(employee.Name);
                        item.SubItems.Add(employee.Email);
                        item.SubItems.Add(employee.ContactNo);
                        item.SubItems.Add(employee.Address);
                        item.SubItems.Add(employee.CurrentDesignation.Title);
                        item.SubItems.Add(employee.JoiningDate.ToShortDateString());

                        listViewEmployeList.Items.Add(item);
                    }
                    
                }
            }
        }

        private bool IsEmailValid()
        {
            string email = textBoxEmail.Text;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                MessageBox.Show("Email is not valid");
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisbableAndBacktoNewButton();
        }
    }
}
