using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace NFFM
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Text = "NFFM Launcher";
        }
        int selectedRow;
       

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nFFM_be_sqlDataSet1.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.nFFM_be_sqlDataSet1.tblCustomers);

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            cust.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

           
        }

        private void btnSalesCode_Click(object sender, EventArgs e)
        {
            SalesCode SC = new SalesCode();
            SC.ShowDialog();
        }

        private void btnShipper_Click(object sender, EventArgs e)
        {
            Shipper shipper = new Shipper();
            shipper.ShowDialog();
        }

        private void btnTrucker_Click(object sender, EventArgs e)
        {
            Trucker trucker = new Trucker();
            trucker.ShowDialog();
        }

        private void btnBOL_Click(object sender, EventArgs e)
        {
            BillOfLading BOL = new BillOfLading();
            BOL.ShowDialog();
        }

        private void btnFFBOL_Click(object sender, EventArgs e)
        {
            FreightForwardingBOL FFBOL = new FreightForwardingBOL();
            FFBOL.ShowDialog();
        }

        private void btnBOLReport_Click(object sender, EventArgs e)
        {
            BillOfLading_Report BOLReport = new BillOfLading_Report();
            BOLReport.ShowDialog();
        }

        private void btnFFBOLReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Development Phase");
        }
    }
}
