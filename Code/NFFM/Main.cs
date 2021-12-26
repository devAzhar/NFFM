namespace NFFM
{
    using System;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Text = "NFFM Launcher";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nFFM_be_sqlDataSet1.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.nFFM_be_sqlDataSet1.tblCustomers);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            bool isFormOpen = IsAlreadyOpen(typeof(Customers));
            if (isFormOpen == false)
            {
                cust.Show();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {


        }

        private void btnSalesCode_Click(object sender, EventArgs e)
        {
            SalesCode SC = new SalesCode();
            bool isFormOpen = IsAlreadyOpen(typeof(SalesCode));
            if (isFormOpen == false)
            {
                SC.Show();
            }
        }

        private void btnShipper_Click(object sender, EventArgs e)
        {
            Shipper shipper = new Shipper();
            bool isFormOpen = IsAlreadyOpen(typeof(Shipper));
            if (isFormOpen == false)
            {
                shipper.Show();
            }
        }

        private void btnTrucker_Click(object sender, EventArgs e)
        {
            Trucker trucker = new Trucker();
            bool isFormOpen = IsAlreadyOpen(typeof(Trucker));
            if (isFormOpen == false)
            {
                trucker.Show();
            }
        }
        public static bool IsAlreadyOpen(Type formType)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == formType)
                {
                    DBManager.isDataLoaded = true;
                    f.BringToFront();
                    isOpen = true;

                }
            }
            return isOpen;
        }
        private void btnBOL_Click(object sender, EventArgs e)
        {
            BillOfLading BOL = new BillOfLading();
            bool isFormOpen = IsAlreadyOpen(typeof(BillOfLading));
            if (isFormOpen == false)
            {
                BOL.Show();
            }
        }

        private void btnFFBOL_Click(object sender, EventArgs e)
        {
            FreightForwardingBOL FFBOL = new FreightForwardingBOL();
            bool isFormOpen = IsAlreadyOpen(typeof(FreightForwardingBOL));
            if (isFormOpen == false)
            {
                FFBOL.Show();
            }
        }

        private void btnBOLReport_Click(object sender, EventArgs e)
        {
            BillOfLading_Report BOLReport = new BillOfLading_Report();
            bool isFormOpen = IsAlreadyOpen(typeof(BillOfLading_Report));
            if (isFormOpen == false)
            {
                BOLReport.Show();
            }
        }

        private void btnFFBOLReport_Click(object sender, EventArgs e)
        {
            bool isFormOpen = IsAlreadyOpen(typeof(FreightForwardingBOL_Report));
            if (isFormOpen == false)
            {
                FreightForwardingBOL_Report FFBOLReport = new FreightForwardingBOL_Report();
                FFBOLReport.Show();
            }
        }

        private void btnDataFileExport_Click(object sender, EventArgs e)
        {
            bool isFormOpen = IsAlreadyOpen(typeof(FreightForwardingBOL_DataFileExport));

            if (isFormOpen == false)
            {
                var form = new FreightForwardingBOL_DataFileExport();
                form.Show();
            }
            
        }
    }
}
