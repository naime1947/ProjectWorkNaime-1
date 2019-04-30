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
using System.IO;
using AllClasses;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

        private void btnPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "pdf";
            saveFile.RestoreDirectory = true;
            saveFile.Filter = "Pdf files (*.pdf)|*.pdf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(listViewShowDetails.Columns.Count);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.PaddingTop = 20f;
                pdfTable.WidthPercentage = 80f;
                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.DefaultCell.BorderWidth = 1;

                //Adding Header row
                foreach (ColumnHeader column in listViewShowDetails.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.Text));
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (ListViewItem itemRow in listViewShowDetails.Items)
                {
                    int i = 0;
                    for (i = 0; i <= itemRow.SubItems.Count - 1; i++)
                    {
                        pdfTable.AddCell(itemRow.SubItems[i].Text);
                    }
                }

                //Generating PDF
                Document pdf = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdf, new FileStream(saveFile.FileName, FileMode.Create));
                pdf.Open();
                
                Paragraph p1 = new Paragraph("Total Salary Amount\n");
                p1.Alignment = Element.ALIGN_CENTER;
                Paragraph p2 = new Paragraph("Year : "+comboBoxYear.SelectedItem.ToString()+"\n");
                p2.Alignment = Element.ALIGN_CENTER;
                Paragraph p3 = new Paragraph("Month : " + comboBoxMonth.SelectedItem.ToString()+"\n\n");
                p3.Alignment = Element.ALIGN_CENTER;
                Paragraph p4 = new Paragraph("Total Amount : " + textBoxTotal.Text + "\n\n");
                p4.Alignment = Element.ALIGN_CENTER;
                pdf.Add(p1);
                pdf.Add(p2);
                pdf.Add(p3);
                pdf.Add(p4);
                pdf.Add(pdfTable);
                pdf.Close();
                MessageBox.Show("Pdf Generated. Location : " + saveFile.FileName);
            }
            
        }
    }
}
