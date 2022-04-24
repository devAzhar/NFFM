using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFFM
{
    public partial class FreightForwardingBOL_DataFileExport : Form
    {
        public FreightForwardingBOL_DataFileExport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private static void CloseIfOpened(Type formType)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == formType)
                {
                    f.Close();
                    break;
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            CloseIfOpened(typeof(BillOfLading_Report));

            DBManager.ReportingDateCaller = string.Empty;
            DBManager.ReportingDate = radioButton1.Checked ? datePickerReceived.Value.ToString("yyyy-MM-dd") : datePickerWeekEnding.Value.ToString("yyyy-MM-dd");
            DBManager.ReportingDateType = radioButton1.Checked ? "Received" : "WeekEnding";
            //this.Close();

            var bolReportingForm = new BillOfLading_Report();
            bolReportingForm.Show();
        }
    }
}
