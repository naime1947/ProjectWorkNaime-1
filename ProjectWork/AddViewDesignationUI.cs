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
    public partial class AddViewDesignationUI : Form
    {
        private List<Designation> designationList;

        public AddViewDesignationUI()
        {
            InitializeComponent();
        }

        public AddViewDesignationUI(List<Designation> designationList) :this()
        {
            this.designationList = designationList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Designation designation = new Designation() {
                Title = textBoxTitle.Text,
                Code = textBoxCode.Text,
                SalaryBasic = Convert.ToDouble(textBoxSalaryBasic.Text),
                HouseRent = Convert.ToDouble(textBoxHouseRent.Text),
                MedicalAmount = Convert.ToDouble(textBoxMedicalAmount.Text),
                Total = Convert.ToDouble(textBoxTotal.Text)
            };


            designationList.Add(designation);
            PopulateListViewWithDesignation();

        }

        private void PopulateListViewWithDesignation()
        {
            listViewDesignationView.Items.Clear();
            
            if (designationList != null)
            {
                foreach (var designation in designationList)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(designation.Title);
                    item.SubItems.Add(designation.Code);
                    item.SubItems.Add(designation.SalaryBasic.ToString());
                    item.SubItems.Add(designation.HouseRent.ToString());
                    item.SubItems.Add(designation.MedicalAmount.ToString());
                    item.SubItems.Add(designation.Total.ToString());

                    listViewDesignationView.Items.Add(item);

                }
            }
           
            
        }

        private void AddViewDesignationUI_Load(object sender, EventArgs e)
        {
            PopulateListViewWithDesignation();
        }
    }
}
