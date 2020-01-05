namespace NFFM
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class BillOfLading_Report : Form
    {
        public BillOfLading_Report()
        {
            InitializeComponent();
            this.Text = "NFFM";
            DBManager.isDataLoaded = false;

            rbtReceivedAll.Checked = true;
            ddlReceived.Text = "";
            ddlReceived.Enabled = false;

            rbtBatchAll.Checked = true;
            ddlBatch.Text = "";
            ddlBatch.Enabled = false;

            rbtInvoiceAll.Checked = true;
            ddlInvoice.Text = "";
            ddlInvoice.Enabled = false;

            rbtBillOfLadingAll.Checked = true;
            ddlBillOfLading.Text = "";
            ddlBillOfLading.Enabled = false;

            rbtCustomerAll.Checked = true;
            ddlCustomer.Text = "";
            ddlCustomer.Enabled = false;
        }

        int initialDataLoaded = 0;
        int isButtonClicked = 0;
        string currentReceivingId = "0";
        string selectedReceivedDate = "0";
        string selectedBatch = "0";
        string selectedBillOfLading = "0";
        string selectedCustomerName = "0";
        int previousReceivingId = 0;
        int firstReceivingId = 0;
        int nextReceivingId = 0;
        int lastReceivingId = 0;
        int IsNewRecord = 0;
        int lineItemId;
        DataGridViewRow row;
        Dictionary<string, string> ddlCustomers = new Dictionary<string, string>();
        //Dictionary<string, string> ddlReceivedDate = new Dictionary<string, string>();
        Dictionary<string, string> ReceivedDateItems = new Dictionary<string, string>();
        Dictionary<string, string> BatchItems = new Dictionary<string, string>();
        Dictionary<string, string> BillOfLadingItems = new Dictionary<string, string>();
        Dictionary<string, string> CustomersItems = new Dictionary<string, string>();
        DataTable dtCustomers;
        DataTable dtReceived;
        DataTable dtBatch;

        bool IsReceivedChecked = true;
        bool IsBatchChecked = true;
        bool IsInvoiceChecked = true;
        bool IsBillOfLadingChecked = true;
        bool IsCustomerChecked = true;


        public void LoadData(string receivedDate, string batchId, string invoideNumbers, string billOfLadingNumber, string customerName)
        {
            String SPName = "BillOfLading_Report_GetAll";
            //ddlCustomers.Clear();
            //ddlReceivedDate.Clear();
            //ddlBatch1.Clear();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = SPName;
            //cmd.Parameters.Add("receivingId", receivingId);
            //cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = DBManager.GetDataSet_Report(SPName, receivedDate, batchId, invoideNumbers, billOfLadingNumber, customerName, false);
            // DataSet ds = DBManager.GetDataSet(SPName, cmd);



            DataTable dtLineItems = ds.Tables[0];
            dtReceived = ds.Tables[1];
            dtBatch = ds.Tables[2];
            DataTable dtBillOfLading = ds.Tables[3];
            dtCustomers = ds.Tables[4];
            // dtReceived = ds.Tables[4];
            // dtBatch = ds.Tables[5];
            //selectedReceivedDate = "0";
            //datePickerReceived.Value = new DateTime(1900, 01, 01);
            //datePickerWeekEnding.Value = new DateTime(1900, 01, 01);
            if (selectedReceivedDate == "0")
            {
                selectedReceivedDate = DateTime.Parse(dtReceived.Rows[0]["ReceivedDate"].ToString()).ToShortDateString();
            }
            if (selectedBatch == "0")
            {
                selectedBatch = dtBatch.Rows[0]["BatchID"].ToString();
            }
            if (selectedBillOfLading == "0")
            {
                selectedBillOfLading = dtBillOfLading.Rows[0]["BillOfLadingNumber"].ToString();
            }
            if (selectedCustomerName == "0")
            {
                selectedCustomerName = dtCustomers.Rows[0]["Name"].ToString();
            }
            if (ds.Tables.Count > 0)
            {
                if (dtReceived.Rows.Count > 0 && ReceivedDateItems.Count == 0)
                {
                    for (int i = 0; i < dtReceived.Rows.Count; i++)
                    {
                        ReceivedDateItems.Add(DateTime.Parse(dtReceived.Rows[i]["ReceivedDate"].ToString()).ToShortDateString(), DateTime.Parse(dtReceived.Rows[i]["ReceivedDate"].ToString()).ToShortDateString());
                    }
                    ddlReceived.DataSource = new BindingSource(ReceivedDateItems, null);
                    ddlReceived.DisplayMember = "Value";
                    ddlReceived.ValueMember = "Key";
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
                if (dtBillOfLading.Rows.Count > 0 && BillOfLadingItems.Count == 0)
                {
                    for (int i = 0; i < dtBillOfLading.Rows.Count; i++)
                    {
                        BillOfLadingItems.Add(dtBillOfLading.Rows[i]["BillofLadingNumber"].ToString(), dtBillOfLading.Rows[i]["BillofLadingNumber"].ToString());
                    }
                    ddlBillOfLading.DataSource = new BindingSource(BillOfLadingItems, null);
                    ddlBillOfLading.DisplayMember = "Value";
                    ddlBillOfLading.ValueMember = "Key";
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
        private void ddlReceived_SelectedIndexChanged(object sender, EventArgs e)
        {
            string receivedDateId = ((KeyValuePair<string, string>)ddlReceived.SelectedItem).Key;
            string receivedDate = ((KeyValuePair<string, string>)ddlReceived.SelectedItem).Value;

            string recDate = receivedDate;
            string batchId = selectedBatch;
            string bol = selectedBillOfLading;
            string custName = selectedCustomerName;
            selectedReceivedDate = receivedDate;

            if (rbtReceivedAll.Checked)
            {
                recDate = "";
            }
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            if (rbtBillOfLadingAll.Checked)
            {
                bol = "";
            }
            if (rbtCustomerAll.Checked)
            {
                custName = "";
            }


            //            DataSet ds = DBManager.GetDataSet_Report(SPName, recDate, batchId, "", bol, custName);

            LoadData(recDate, batchId, "", bol, custName);
            //if (selectedReceivedDate != receivedDate && selectedReceivedDate != "0" && initialDataLoaded == 1)
            //{
            //    string batchId = selectedBatch;
            //    if (rbtBatchAll.Checked)
            //    {
            //        batchId = "";
            //    }
            //    string BOL = selectedBillOfLading;
            //    if (rbtBillOfLadingAll.Checked)
            //    {
            //        BOL = "";
            //    }
            //    selectedReceivedDate = receivedDate;
            //    LoadData(receivedDate, batchId, "", BOL, "");
            //}
        }
        private void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string batchId = ((KeyValuePair<string, string>)ddlBatch.SelectedItem).Key;
            string batch = ((KeyValuePair<string, string>)ddlBatch.SelectedItem).Value;
            if (selectedBatch != batchId && selectedBatch != "0" && initialDataLoaded == 1)
            {
                string recDate = selectedReceivedDate;
                if (rbtReceivedAll.Checked)
                {
                    recDate = "";
                }
                string BOL = selectedBillOfLading;
                if (rbtBillOfLadingAll.Checked)
                {
                    BOL = "";
                }
                selectedBatch = batchId;
                LoadData(recDate, selectedBatch, "", BOL, "");

            }
        }
        private void ddlBillOfLading_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BillOfLadingId = ((KeyValuePair<string, string>)ddlBillOfLading.SelectedItem).Key;
            string BillOfLading = ((KeyValuePair<string, string>)ddlBillOfLading.SelectedItem).Value;

            if (selectedBillOfLading != BillOfLading && selectedBillOfLading != "0" && initialDataLoaded == 1)
            {
                string recDate = selectedReceivedDate;
                if (rbtReceivedAll.Checked)
                {
                    recDate = "";
                }
                string batchId = selectedBatch;
                if (rbtBatchAll.Checked)
                {
                    batchId = "";
                }
                selectedBillOfLading = BillOfLading;
                LoadData(recDate, batchId, "", selectedBillOfLading, "");

            }
        }
        private void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CustomerId = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            string Customer = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Value;

            if (selectedCustomerName.Trim() != Customer.Trim() && selectedCustomerName.Trim() != "0" && initialDataLoaded == 1)
            {
                string recDate = selectedReceivedDate;
                if (rbtReceivedAll.Checked)
                {
                    recDate = "";
                }
                string batchId = selectedBatch;
                if (rbtBatchAll.Checked)
                {
                    batchId = "";
                }
                string BOL = selectedBillOfLading;
                if (rbtBillOfLadingAll.Checked)
                {
                    BOL = "";
                }
                selectedCustomerName = Customer;
                LoadData(recDate, batchId, "", BOL, selectedCustomerName);
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

            dataGridView1.Columns["ReceivedDate"].HeaderText = "Received Date";
            dataGridView1.Columns["ReceivedDate"].Width = 140;
            dataGridView1.Columns["BatchID"].HeaderText = "Batch ID";
            dataGridView1.Columns["BatchID"].Width = 110;

            //dataGridView1.Columns["receivingId"].Visible = false;
            //dataGridView1.Columns["lineitemId"].Visible = false;
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
            dataGridView1.Columns["UnitOfMeasure"].Width = 195;
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
            dataGridView1.Columns["ReceivedDate"].ReadOnly = true;
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
            //ddlReceived.Text = "";
            ddlReceived.Enabled = true;
        }
        private void rbtBatch_Click(object sender, EventArgs e)
        {
            rbtBatchAll.Checked = false;
            rbtBatch.Checked = true;
            //ddlReceived.Text = "";
            ddlBatch.Enabled = true;
        }
        private void rbtBillOfLading_Click(object sender, EventArgs e)
        {
            rbtBillOfLadingAll.Checked = false;
            rbtBillOfLading.Checked = true;
            //ddlReceived.Text = "";
            ddlBillOfLading.Enabled = true;

        }
        private void rbtCustomer_Click(object sender, EventArgs e)
        {
            rbtCustomerAll.Checked = false;
            rbtCustomer.Checked = true;
            //ddlReceived.Text = "";
            ddlCustomer.Enabled = true;
        }
        private void rbtReceivedAll_Click(object sender, EventArgs e)
        {
            rbtReceivedAll.Checked = true;
            rbtReceived.Checked = false;
            //ddlReceived.Text = "";
            ddlReceived.Enabled = false;

            string batchId = selectedReceivedDate;
            string bol = selectedBillOfLading;
            string custName = selectedCustomerName;

            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            if (rbtBillOfLadingAll.Checked)
            {
                bol = "";
            }
            if (rbtCustomerAll.Checked)
            {
                custName = "";
            }

            LoadData("", batchId, "", bol, custName);
        }

        private void rbtBatchAll_Click(object sender, EventArgs e)
        {
            rbtBatchAll.Checked = true;
            rbtBatch.Checked = false;
            //ddlReceived.Text = "";
            ddlBatch.Enabled = false;

            string recDate = selectedReceivedDate;
            string bol = selectedBillOfLading;
            string custName = selectedCustomerName;

            if (rbtReceivedAll.Checked)
            {
                recDate = "";
            }
            if (rbtBillOfLadingAll.Checked)
            {
                bol = "";
            }
            if (rbtCustomerAll.Checked)
            {
                custName = "";
            }

            LoadData(recDate, "", "", bol, custName);

        }
        private void rbtBillOfLadingAll_Click(object sender, EventArgs e)
        {
            rbtBillOfLadingAll.Checked = true;
            rbtBillOfLading.Checked = false;
            //ddlReceived.Text = "";
            ddlBillOfLading.Enabled = false;

            string recDate = selectedReceivedDate;
            string batchId = selectedBatch;
            string custName = selectedCustomerName;

            if (rbtReceivedAll.Checked)
            {
                recDate = "";
            }
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            if (rbtCustomerAll.Checked)
            {
                custName = "";
            }

            LoadData(recDate, batchId, "", "", custName);

        }
        private void rbtCustomerAll_Click(object sender, EventArgs e)
        {
            rbtCustomerAll.Checked = true;
            rbtCustomer.Checked = false;
            //ddlReceived.Text = "";
            ddlCustomer.Enabled = false;

            string recDate = selectedReceivedDate;
            string batchId = selectedBatch;
            string BOL = selectedBillOfLading;

            if (rbtReceivedAll.Checked)
            {
                recDate = "";
            }
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            if (rbtBillOfLadingAll.Checked)
            {
                BOL = "";
            }
            LoadData(recDate, batchId, "", BOL, "");
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
        }

        private void BOL_Print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void btnCreateReport_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Data is Exporting in Excel, Please wait...";
            label1.ForeColor = Color.Red;
            label1.Font = new Font(label1.Font, label1.Font.Style | FontStyle.Bold);
            String SPName = "BillOfLading_Report_GetAll";

            string recDate = selectedReceivedDate;
            string batchId = selectedBatch;
            string bol = selectedBillOfLading;
            string custName = selectedCustomerName;

            if (rbtReceivedAll.Checked)
            {
                recDate = "";
            }
            if (rbtBatchAll.Checked)
            {
                batchId = "";
            }
            if (rbtBillOfLadingAll.Checked)
            {
                bol = "";
            }
            if (rbtCustomerAll.Checked)
            {
                custName = "";
            }
            using (var ds = DBManager.GetDataSet_Report(SPName, recDate, batchId, "", bol, custName, true))
            {
                var dtBOLReport = ds.Tables[0];

                //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                //worksheet = workbook.Sheets["Sheet1"];
                //worksheet = workbook.ActiveSheet;
                //worksheet.Name = "BillOfLading";
                //for (int i = 1; i < dtBOLReport.Columns.Count + 1; i++)
                //{
                //    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                //}
                //for (int i = 0; i < dtBOLReport.Rows.Count - 1; i++) // tmep - 1
                //{
                //    for (int j = 0; j < dtBOLReport.Columns.Count; j++)
                //    {
                //        worksheet.Cells[i + 2, j + 1] = dtBOLReport.Rows[i][j];
                //    }
                //}
                var saveFileDialogue = new SaveFileDialog();
                saveFileDialogue.FileName = "BillOfLadingReport_" + DateTime.Now.Ticks;
                saveFileDialogue.DefaultExt = ".csv";

                if (saveFileDialogue.ShowDialog() == DialogResult.OK)
                {
                    dtBOLReport.WriteToCsvFile(saveFileDialogue.FileName);
                    // workbook.SaveAs(saveFileDialogue.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
            }

            label1.Text = "Click a heading to sort the data.";
            label1.ForeColor = Color.Black;
            label1.Font = new Font(label1.Font, label1.Font.Style & ~FontStyle.Bold);
            //app.Quit();
        }
    }
}
