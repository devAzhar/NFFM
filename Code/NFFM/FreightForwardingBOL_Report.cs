using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFFM
{
    public partial class FreightForwardingBOL_Report : Form
    {
        public FreightForwardingBOL_Report()
        {
            InitializeComponent();
            this.Text = "NFFM";
            DBManager.isDataLoaded = false;

            rbtReceivedAll.Checked = true;
            ddlShipped.Text = "";
            ddlShipped.Enabled = false;

            rbtBatchAll.Checked = true;
            ddlBatch.Text = "";
            ddlBatch.Enabled = false;

            rbtInvoiceAll.Checked = true;
            ddlInvoice.Text = "";
            ddlInvoice.Enabled = false;

            rbtFreightForwardingBOLAll.Checked = true;
            ddlFreightForwardingBOL.Text = "";
            ddlFreightForwardingBOL.Enabled = false;

            rbtCustomerAll.Checked = true;
            ddlCustomer.Text = "";
            ddlCustomer.Enabled = false;
        }
        int initialDataLoaded = 0;
        int isButtonClicked = 0;
        string currentshippingId = "0";
        string selectedshippedDate = "0";
        string selectedBatch = "0";
        string selectedFreightForwardingBOL = "0";
        string selectedCustomerName = "0";
        int previousshippingId = 0;
        int firstshippingId = 0;
        int nextshippingId = 0;
        int lastshippingId = 0;
        int IsNewRecord = 0;
        int lineItemId;
        DataGridViewRow row;
        Dictionary<string, string> ddlCustomers = new Dictionary<string, string>();
        //Dictionary<string, string> ddlshippedDate = new Dictionary<string, string>();
        Dictionary<string, string> shippedDateItems = new Dictionary<string, string>();
        Dictionary<string, string> BatchItems = new Dictionary<string, string>();
        Dictionary<string, string> FreightForwardingBOLItems = new Dictionary<string, string>();
        Dictionary<string, string> CustomersItems = new Dictionary<string, string>();
        DataTable dtCustomers;
        DataTable dtReceived;
        DataTable dtBatch;

        bool IsReceivedChecked = true;
        bool IsBatchChecked = true;
        bool IsInvoiceChecked = true;
        bool IsFreightForwardingBOLChecked = true;
        bool IsCustomerChecked = true;


        public void LoadData(string shippedDate, string batchId, string invoideNumbers, string BillOfLadingNumber, string customerName)
        {
            String SPName = "FreightForwardingBOL_Report_GetAll";
            //ddlCustomers.Clear();
            //ddlshippedDate.Clear();
            //ddlBatch1.Clear();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = SPName;
            //cmd.Parameters.Add("shippingId", shippingId);
            //cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = DBManager.GetDataSet_FreightForwardingReport(SPName, shippedDate, batchId, invoideNumbers, BillOfLadingNumber, customerName);
            // DataSet ds = DBManager.GetDataSet(SPName, cmd);



            DataTable dtLineItems = ds.Tables[0];
            dtReceived = ds.Tables[1];
            dtBatch = ds.Tables[2];
            DataTable dtFreightForwardingBOL = ds.Tables[3];
            dtCustomers = ds.Tables[4];
            // dtReceived = ds.Tables[4];
            // dtBatch = ds.Tables[5];
            //selectedshippedDate = "0";
            //datePickerReceived.Value = new DateTime(1900, 01, 01);
            //datePickerWeekEnding.Value = new DateTime(1900, 01, 01);
            if (selectedshippedDate == "0")
            {
                selectedshippedDate = DateTime.Parse(dtReceived.Rows[0]["shippedDate"].ToString()).ToShortDateString();
            }
            if (selectedBatch == "0")
            {
                selectedBatch = dtBatch.Rows[0]["BatchID"].ToString();
            }
            if (selectedFreightForwardingBOL == "0")
            {
                selectedFreightForwardingBOL = dtFreightForwardingBOL.Rows[0]["BillOfLadingNumber"].ToString();
            }
            if (selectedCustomerName == "0")
            {
                selectedCustomerName = dtCustomers.Rows[0]["Name"].ToString();
            }
            if (ds.Tables.Count > 0)
            {
                if (dtReceived.Rows.Count > 0 && shippedDateItems.Count == 0)
                {
                    for (int i = 0; i < dtReceived.Rows.Count; i++)
                    {
                        shippedDateItems.Add(DateTime.Parse(dtReceived.Rows[i]["shippedDate"].ToString()).ToShortDateString(), DateTime.Parse(dtReceived.Rows[i]["shippedDate"].ToString()).ToShortDateString());
                    }
                    ddlShipped.DataSource = new BindingSource(shippedDateItems, null);
                    ddlShipped.DisplayMember = "Value";
                    ddlShipped.ValueMember = "Key";
                }

                if (dtBatch.Rows.Count > 0 && BatchItems.Count == 0)
                {
                    for (int i = 0; i < dtBatch.Rows.Count; i++)
                    {
                        BatchItems.Add(dtBatch.Rows[i]["BatchID"].ToString(), dtBatch.Rows[i]["BatchID"].ToString());
                    }
                    ddlBatch.DataSource = new BindingSource(BatchItems, null);
                    ddlBatch.DisplayMember = "Value";
                    ddlBatch.ValueMember = "Key";
                }
                if (dtFreightForwardingBOL.Rows.Count > 0 && FreightForwardingBOLItems.Count == 0)
                {
                    for (int i = 0; i < dtFreightForwardingBOL.Rows.Count; i++)
                    {
                        FreightForwardingBOLItems.Add(dtFreightForwardingBOL.Rows[i]["BillOfLadingNumber"].ToString(), dtFreightForwardingBOL.Rows[i]["BillOfLadingNumber"].ToString());
                    }
                    ddlFreightForwardingBOL.DataSource = new BindingSource(FreightForwardingBOLItems, null);
                    ddlFreightForwardingBOL.DisplayMember = "Value";
                    ddlFreightForwardingBOL.ValueMember = "Key";
                }
                if (dtCustomers.Rows.Count > 0 && CustomersItems.Count == 0)
                {
                    for (int i = 0; i < dtCustomers.Rows.Count; i++)
                    {
                        CustomersItems.Add(dtCustomers.Rows[i]["customerID"].ToString(), dtCustomers.Rows[i]["Name"].ToString());
                    }
                    ddlCustomer.DataSource = new BindingSource(CustomersItems, null);
                    ddlCustomer.DisplayMember = "Value";
                    ddlCustomer.ValueMember = "Key";
                }


                if (dtCustomers.Rows.Count > 0 && ddlCustomers.Count == 0)
                {
                    for (int i = 0; i < dtCustomers.Rows.Count; i++)
                    {
                        ddlCustomers.Add(dtCustomers.Rows[i]["customerID"].ToString(), dtCustomers.Rows[i]["Name"].ToString());
                    }
                }
                if (dtLineItems.Rows.Count > 0)
                {

                    BindLineItems(dtLineItems);
                }
                else
                {
                    BindLineItems(dtLineItems);
                }
            }
        }
        private void ddlShipped_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shippedDateId = ((KeyValuePair<string, string>)ddlShipped.SelectedItem).Key;
            string shippedDate = ((KeyValuePair<string, string>)ddlShipped.SelectedItem).Value;

            if (selectedshippedDate != shippedDate && selectedshippedDate != "0" && initialDataLoaded == 1)
            {
                string batchId = selectedBatch;
                if (rbtBatchAll.Checked)
                {
                    batchId = "";
                }
                string BOL = selectedFreightForwardingBOL;
                if (rbtFreightForwardingBOLAll.Checked)
                {
                    BOL = "";
                }
                selectedshippedDate = shippedDate;
                LoadData(shippedDate, batchId, "", BOL, "");
            }
        }
        private void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string batchId = ((KeyValuePair<string, string>)ddlBatch.SelectedItem).Key;
            string batch = ((KeyValuePair<string, string>)ddlBatch.SelectedItem).Value;
            if (selectedBatch != batchId && selectedBatch != "0" && initialDataLoaded == 1)
            {
                string shipDate = selectedshippedDate;
                if (rbtReceivedAll.Checked)
                {
                    shipDate = "";
                }
                string BOL = selectedFreightForwardingBOL;
                if (rbtFreightForwardingBOLAll.Checked)
                {
                    BOL = "";
                }
                selectedBatch = batchId;
                LoadData(shipDate, selectedBatch, "", BOL, "");

            }
        }
        private void ddlFreightForwardingBOL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FreightForwardingBOLId = ((KeyValuePair<string, string>)ddlFreightForwardingBOL.SelectedItem).Key;
            string FreightForwardingBOL = ((KeyValuePair<string, string>)ddlFreightForwardingBOL.SelectedItem).Value;

            if (selectedFreightForwardingBOL != FreightForwardingBOL && selectedFreightForwardingBOL != "0" && initialDataLoaded == 1)
            {
                string shipDate = selectedshippedDate;
                if (rbtReceivedAll.Checked)
                {
                    shipDate = "";
                }
                string batchId = selectedBatch;
                if (rbtBatchAll.Checked)
                {
                    batchId = "";
                }
                selectedFreightForwardingBOL = FreightForwardingBOL;
                LoadData(shipDate, batchId, "", selectedFreightForwardingBOL, "");

            }
        }
        private void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CustomerId = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            string Customer = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Value;

            if (selectedCustomerName.Trim() != Customer.Trim() && selectedCustomerName.Trim() != "0" && initialDataLoaded == 1)
            {
                string shipDate = selectedshippedDate;
                if (rbtReceivedAll.Checked)
                {
                    shipDate = "";
                }
                string batchId = selectedBatch;
                if (rbtBatchAll.Checked)
                {
                    batchId = "";
                }
                string BOL = selectedFreightForwardingBOL;
                if (rbtFreightForwardingBOLAll.Checked)
                {
                    BOL = "";
                }
                selectedCustomerName = Customer;
                LoadData(shipDate, batchId, "", BOL, selectedCustomerName);
            }
        }
        public void BindLineItems(DataTable dtLineItems)
        {
            Decimal totalTrucking = 0;
            if (dtLineItems.Rows.Count > 0)
            {
                for (int i = 0; i < dtLineItems.Rows.Count; i++)
                {
                    totalTrucking = totalTrucking + Convert.ToDecimal(dtLineItems.Rows[i]["Ext"]);
                }
            }
            totalTrucking = Math.Round(totalTrucking, 2);
            txtTruckingTotal.Text = "$" + totalTrucking.ToString();
            txtTruckingTotal.BackColor = Color.Yellow;

            dataGridView1.DataSource = dtLineItems;

            dataGridView1.Columns["shippedDate"].HeaderText = "Shipped Date";
            dataGridView1.Columns["shippedDate"].Width = 140;
            dataGridView1.Columns["BatchID"].HeaderText = "Batch ID";
            //dataGridView1.Columns["BatchID"].Width = 110;

            dataGridView1.Columns["shippingId"].Visible = false;
            dataGridView1.Columns["lineitemId"].Visible = false;
            dataGridView1.Columns["BillOfLadingNumber"].Width = 150;
            dataGridView1.Columns["BillOfLadingNumber"].HeaderText = "Bill of Lading #";
            dataGridView1.Columns["InvoiceNumber"].Width = 110;
            dataGridView1.Columns["InvoiceNumber"].HeaderText = "Invoice #";
            dataGridView1.Columns["CustomerName"].Width = 250;
            dataGridView1.Columns["CustomerName"].HeaderText = "Customer";
            dataGridView1.Columns["SalesCode"].Width = 130;
            dataGridView1.Columns["SalesCode"].HeaderText = "Sales Code";
            dataGridView1.Columns["Description"].Width = 120;
            dataGridView1.Columns["UnitOfMeasure"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["UnitOfMeasure"].Width = 193;
            dataGridView1.Columns["Qty"].Width = 50;
            dataGridView1.Columns["Price"].Width = 75;
            dataGridView1.Columns["Ext"].Width = 75;

            dataGridView1.BorderStyle = BorderStyle.None;
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.Columns["UnitOfMeasure"].DefaultCellStyle.BackColor = Color.Yellow; //"#FFFC8B";
            dataGridView1.Columns["Ext"].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.Columns["Description"].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.Columns["Price"].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["Ext"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Ext"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DBManager.isDataLoaded = true;
            //dataGridView1.AllowUserToAddRows = true;

            dataGridView1.Columns["BillOfLadingNumber"].ReadOnly = true;
            dataGridView1.Columns["CustomerName"].ReadOnly = true;
            dataGridView1.Columns["Shipper"].ReadOnly = true;
            dataGridView1.Columns["SalesCode"].ReadOnly = true;
            dataGridView1.Columns["Qty"].ReadOnly = true;
            dataGridView1.Columns["shippedDate"].ReadOnly = true;
            dataGridView1.Columns["BatchID"].ReadOnly = true;
            dataGridView1.Columns["InvoiceNumber"].ReadOnly = true;
            dataGridView1.Columns["Description"].ReadOnly = true;
            dataGridView1.Columns["UnitOfMeasure"].ReadOnly = true;
            dataGridView1.Columns["Price"].ReadOnly = true;
            dataGridView1.Columns["Ext"].ReadOnly = true;

            label1.Text = "Click a heading to sort the data.";
            label1.Font = new Font(label1.Font, FontStyle.Regular);
            label1.Font = new System.Drawing.Font(label1.Font.FontFamily.Name, 10);
            label1.BackColor = Color.Transparent;

        }
        private void Form1_Activated(object sender, EventArgs e)
        {

            if (DBManager.isDataLoaded == false)
            {
                LoadData("", "", "", "", "");
                initialDataLoaded = 1;
            }
            // LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void rbtReceived_Click(object sender, EventArgs e)
        {
            rbtReceivedAll.Checked = false;
            rbtReceived.Checked = true;
            //ddlShipped.Text = "";
            ddlShipped.Enabled = true;
        }
        private void rbtBatch_Click(object sender, EventArgs e)
        {
            rbtBatchAll.Checked = false;
            rbtBatch.Checked = true;
            //ddlShipped.Text = "";
            ddlBatch.Enabled = true;
        }
        private void rbtFreightForwardingBOL_Click(object sender, EventArgs e)
        {
            rbtFreightForwardingBOLAll.Checked = false;
            rbtFreightForwardingBOL.Checked = true;
            //ddlShipped.Text = "";
            ddlFreightForwardingBOL.Enabled = true;

        }
        private void rbtCustomer_Click(object sender, EventArgs e)
        {
            rbtCustomerAll.Checked = false;
            rbtCustomer.Checked = true;
            //ddlShipped.Text = "";
            ddlCustomer.Enabled = true;
        }
        private void rbtReceivedAll_Click(object sender, EventArgs e)
        {
            rbtReceivedAll.Checked = true;
            rbtReceived.Checked = false;
            //ddlShipped.Text = "";
            ddlShipped.Enabled = false;
            string batchId = selectedBatch;
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            LoadData("", batchId, "", "", "");
        }

        private void rbtBatchAll_Click(object sender, EventArgs e)
        {
            rbtBatchAll.Checked = true;
            rbtBatch.Checked = false;
            //ddlShipped.Text = "";
            ddlBatch.Enabled = false;
            string shipDate = selectedshippedDate;
            if (rbtReceivedAll.Checked)
            {
                shipDate = "";
            }
            LoadData(shipDate, "", "", "", "");

        }
        private void rbtFreightForwardingBOLAll_Click(object sender, EventArgs e)
        {
            rbtFreightForwardingBOLAll.Checked = true;
            rbtFreightForwardingBOL.Checked = false;
            //ddlShipped.Text = "";
            ddlFreightForwardingBOL.Enabled = false;
            string shipDate = selectedshippedDate;
            if (rbtReceivedAll.Checked)
            {
                shipDate = "";
            }
            string batchId = selectedBatch;
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            LoadData(shipDate, batchId, "", "", "");

        }
        private void rbtCustomerAll_Click(object sender, EventArgs e)
        {
            rbtCustomerAll.Checked = true;
            rbtCustomer.Checked = false;
            //ddlShipped.Text = "";
            ddlCustomer.Enabled = false;
            string shipDate = selectedshippedDate;
            if (rbtReceivedAll.Checked)
            {
                shipDate = "";
            }
            string batchId = selectedBatch;
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            string BOL = selectedFreightForwardingBOL;
            if (rbtFreightForwardingBOLAll.Checked)
            {
                BOL = "";
            }
            LoadData(shipDate, batchId, "", BOL, "");
        }
        Bitmap bitmap;
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            //BOL_PrintPreviewDialog.Document = BOL_Print;
            //BOL_PrintPreviewDialog.ShowDialog();


            int height = dataGridView1.Height;
            int Width = dataGridView1.Width;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            BOL_Print.DefaultPageSettings.Landscape = true;

            //BOL_Print.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 1330, height);

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;
            //Show the Print Preview Dialog.
            BOL_PrintPreviewDialog.Document = BOL_Print;
            BOL_PrintPreviewDialog.PrintPreviewControl.Zoom = 1;
            BOL_PrintPreviewDialog.ShowDialog();

            //Bitmap bitmap;

            ////Resize DataGridView to full height.
            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            ////Create a Bitmap and draw the DataGridView on it.
            //bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            ////Resize DataGridView back to original height.
            //dataGridView1.Height = height;

            ////Show the Print Preview Dialog.
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //printPreviewDialog1.ShowDialog();

        }

        private void BOL_Print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        //private void ddlShipped_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        //private void dataGridView1_Paint(object sender, PaintEventArgs e)
        //{

        //    //DataGridView datagridview1 = (DataGridView)sender;

        //    //if (datagridview1.Rows.Count == 1)
        //    //{
        //    //    using (Graphics g = e.Graphics)
        //    //    {
        //    //        g.FillRectangle(Brushes.Yellow, new Rectangle(new Point(), new Size(datagridview1.Width, 25)));
        //    //        g.DrawString("Select a Trucker Name to continue.", new Font("Arial", 12), Brushes.Red, new PointF(3, 3));
        //    //    }
        //    //}
        //}
    }
}
