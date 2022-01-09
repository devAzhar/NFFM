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

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DBManager.ReportingDate = radioButton1.Checked ? datePickerReceived.Value.ToString("yyyy-MM-dd") : datePickerWeekEnding.Value.ToString("yyyy-MM-dd");
            DBManager.ReportingDateType = radioButton1.Checked ? "Received" : "WeekEnding";
            this.Close();

            var bolReportingForm = new BillOfLading_Report();
            bolReportingForm.Show();
        }
    }
}
