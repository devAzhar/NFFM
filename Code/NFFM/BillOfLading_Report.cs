﻿namespace NFFM
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class BillOfLading_Report : Form
    {
        private int CurrentPageNumber { get; set; } = 1;

        public BillOfLading_Report()
        {
            InitializeComponent();
            this.Text = "NFFM";
            DBManager.isDataLoaded = false;
        }

        int initialDataLoaded = 0;

        public void LoadData(string receivedDate, string batchId, string invoideNumbers, string billOfLadingNumber, string customerName, int pageNumber = 1)
        {
            var SPName = "BillOfLading_Report_GetAll";
            batchId = this.txtBatchId.Text;
            invoideNumbers = this.txtInvoiceNumber.Text;
            billOfLadingNumber = this.txtBillOfLanding.Text;
            customerName = this.txtCustomer.Text;

            var ds = DBManager.GetDataSet_Report(SPName, receivedDate, batchId, invoideNumbers, billOfLadingNumber, customerName, false, pageNumber);
            var dtLineItems = ds.Tables[0];

            if (ds.Tables.Count > 0)
            {
                BindLineItems(dtLineItems);
                lblPageSize.Visible = btnNext.Visible = btnPrevious.Visible = btnCreateReport.Enabled = dtLineItems.Rows.Count > 0;

                if (dtLineItems.Rows.Count > 0)
                {
                    var totalPages = dtLineItems.Rows[0]["TotalPages"].ToString();

                    lblPageSize.Visible = true;
                    lblPageSize.Text = string.Format("Page {0} of {1}", pageNumber, totalPages);

                    btnNext.Enabled = (totalPages != pageNumber.ToString());
                    btnPrevious.Enabled = (pageNumber > 1);
                }
            }
        }
        private void ddlReceived_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string receivedDateId = ((KeyValuePair<string, string>)ddlReceived.SelectedItem).Key;
            //string receivedDate = ((KeyValuePair<string, string>)ddlReceived.SelectedItem).Value;

            //string recDate = receivedDate;
            //string batchId = selectedBatch;
            //string bol = selectedBillOfLading;
            //string custName = selectedCustomerName;
            //selectedReceivedDate = receivedDate;

            //if (rbtReceivedAll.Checked)
            //{
            //    recDate = "";
            //}
            //if (rbtBatchAll.Checked)
            //{
            //    batchId = "";
            //}
            //if (rbtBillOfLadingAll.Checked)
            //{
            //    bol = "";
            //}
            //if (rbtCustomerAll.Checked)
            //{
            //    custName = "";
            //}


            //            DataSet ds = DBManager.GetDataSet_Report(SPName, recDate, batchId, "", bol, custName);

            // LoadData(recDate, batchId, "", bol, custName);
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
            //string batchId = ((KeyValuePair<string, string>)ddlBatch.SelectedItem).Key;
            //string batch = ((KeyValuePair<string, string>)ddlBatch.SelectedItem).Value;
            //if (selectedBatch != batchId && selectedBatch != "0" && initialDataLoaded == 1)
            //{
            //    string recDate = selectedReceivedDate;
            //    if (rbtReceivedAll.Checked)
            //    {
            //        recDate = "";
            //    }
            //    string BOL = selectedBillOfLading;
            //    if (rbtBillOfLadingAll.Checked)
            //    {
            //        BOL = "";
            //    }
            //    selectedBatch = batchId;
            //    LoadData(recDate, selectedBatch, "", BOL, "");

            //}
        }
        private void ddlBillOfLading_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string BillOfLadingId = ((KeyValuePair<string, string>)ddlBillOfLading.SelectedItem).Key;
            //string BillOfLading = ((KeyValuePair<string, string>)ddlBillOfLading.SelectedItem).Value;

            //if (selectedBillOfLading != BillOfLading && selectedBillOfLading != "0" && initialDataLoaded == 1)
            //{
            //    string recDate = selectedReceivedDate;
            //    if (rbtReceivedAll.Checked)
            //    {
            //        recDate = "";
            //    }
            //    string batchId = selectedBatch;
            //    if (rbtBatchAll.Checked)
            //    {
            //        batchId = "";
            //    }
            //    selectedBillOfLading = BillOfLading;
            //    LoadData(recDate, batchId, "", selectedBillOfLading, "");

            //}
        }
        private void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string CustomerId = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Key;
            //string Customer = ((KeyValuePair<string, string>)ddlCustomer.SelectedItem).Value;

            //if (selectedCustomerName.Trim() != Customer.Trim() && selectedCustomerName.Trim() != "0" && initialDataLoaded == 1)
            //{
            //    string recDate = selectedReceivedDate;
            //    if (rbtReceivedAll.Checked)
            //    {
            //        recDate = "";
            //    }
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
            //    selectedCustomerName = Customer;
            //    LoadData(recDate, batchId, "", BOL, selectedCustomerName);
            //}
        }
        public void BindLineItems(DataTable dtLineItems)
        {
            //dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;

            //Decimal totalTrucking = 0;
            //if (dtLineItems.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtLineItems.Rows.Count; i++)
            //    {
            //        totalTrucking = totalTrucking + Convert.ToDecimal(dtLineItems.Rows[i]["Ext"]);
            //    }
            //}
            // totalTrucking = Math.Round(totalTrucking, 2);
            // txtTruckingTotal.Text = "$" + totalTrucking.ToString();
            // txtTruckingTotal.BackColor = Color.Yellow;

            dataGridView1.DataSource = dtLineItems;

            dataGridView1.Columns["ReceivedDate"].HeaderText = "Received Date";
            dataGridView1.Columns["ReceivedDate"].Width = 140;
            //dataGridView1.Columns["BatchID"].HeaderText = "Batch ID";
            //dataGridView1.Columns["BatchID"].Width = 110;

            //dataGridView1.Columns["receivingId"].Visible = false;
            //dataGridView1.Columns["lineitemId"].Visible = false;
            //dataGridView1.Columns["BillOfLadingNumber"].Width = 150;
            //dataGridView1.Columns["BillOfLadingNumber"].HeaderText = "Bill of Lading #";
            dataGridView1.Columns["InvoiceNumber"].Width = 110;
            dataGridView1.Columns["InvoiceNumber"].HeaderText = "Invoice #";
            dataGridView1.Columns["CustomerName"].Width = 250;
            dataGridView1.Columns["CustomerName"].HeaderText = "Customer";
            dataGridView1.Columns["SalesCode"].Width = 130;
            dataGridView1.Columns["SalesCode"].HeaderText = "Code";
            dataGridView1.Columns["Description"].Width = 120;
            dataGridView1.Columns["UnitOfMeasure"].HeaderText = "Unit";
            dataGridView1.Columns["UnitOfMeasure"].Width = 195;
            dataGridView1.Columns["Qty"].Width = 50;
            dataGridView1.Columns["Price"].Width = 75;
            dataGridView1.Columns["Total"].Width = 75;
            //dataGridView1.Columns["Ext"].Width = 75;

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

            //dataGridView1.Columns["UnitOfMeasure"].DefaultCellStyle.BackColor = Color.Yellow; //"#FFFC8B";
            //dataGridView1.Columns["Ext"].DefaultCellStyle.BackColor = Color.Yellow;
            //dataGridView1.Columns["Description"].DefaultCellStyle.BackColor = Color.Yellow;
            //dataGridView1.Columns["Price"].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "c";
            //dataGridView1.Columns["Ext"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridView1.Columns["Ext"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DBManager.isDataLoaded = true;
            //dataGridView1.AllowUserToAddRows = true;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = true;
            }

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.Columns.Count - 2].Visible = false;

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
            //rbtReceivedAll.Checked = false;
            //rbtReceived.Checked = true;
            ////ddlReceived.Text = "";
            //ddlReceived.Enabled = true;

            //string receivedDate = ((KeyValuePair<string, string>)ddlReceived.SelectedItem).Value;

            //selectedReceivedDate = receivedDate;

            //string batchId = selectedReceivedDate;
            //string bol = selectedBillOfLading;
            //string custName = selectedCustomerName;

            //if (rbtBatchAll.Checked)
            //{
            //    batchId = "";
            //}
            //if (rbtBillOfLadingAll.Checked)
            //{
            //    bol = "";
            //}
            //if (rbtCustomerAll.Checked)
            //{
            //    custName = "";
            //}

            //LoadData(selectedReceivedDate, batchId, "", bol, custName);
        }
        private void rbtBatch_Click(object sender, EventArgs e)
        {
            //rbtBatchAll.Checked = false;
            //rbtBatch.Checked = true;
            ////ddlReceived.Text = "";
            //ddlBatch.Enabled = true;
        }
        private void rbtBillOfLading_Click(object sender, EventArgs e)
        {
            //rbtBillOfLadingAll.Checked = false;
            //rbtBillOfLading.Checked = true;
            ////ddlReceived.Text = "";
            //ddlBillOfLading.Enabled = true;

        }
        private void rbtCustomer_Click(object sender, EventArgs e)
        {
            //rbtCustomerAll.Checked = false;
            //rbtCustomer.Checked = true;
            ////ddlReceived.Text = "";
            //ddlCustomer.Enabled = true;
        }
        private void rbtReceivedAll_Click(object sender, EventArgs e)
        {
            //rbtReceivedAll.Checked = true;
            //rbtReceived.Checked = false;
            ////ddlReceived.Text = "";
            //ddlReceived.Enabled = false;

            //string batchId = selectedReceivedDate;
            //string bol = selectedBillOfLading;
            //string custName = selectedCustomerName;

            //if (rbtBatchAll.Checked)
            //{
            //    batchId = "";
            //}
            //if (rbtBillOfLadingAll.Checked)
            //{
            //    bol = "";
            //}
            //if (rbtCustomerAll.Checked)
            //{
            //    custName = "";
            //}

            //LoadData("", batchId, "", bol, custName);
        }

        private void rbtBatchAll_Click(object sender, EventArgs e)
        {
            //rbtBatchAll.Checked = true;
            //rbtBatch.Checked = false;
            ////ddlReceived.Text = "";
            //ddlBatch.Enabled = false;

            //string recDate = selectedReceivedDate;
            //string bol = selectedBillOfLading;
            //string custName = selectedCustomerName;

            //if (rbtReceivedAll.Checked)
            //{
            //    recDate = "";
            //}
            //if (rbtBillOfLadingAll.Checked)
            //{
            //    bol = "";
            //}
            //if (rbtCustomerAll.Checked)
            //{
            //    custName = "";
            //}

            //LoadData(recDate, "", "", bol, custName);

        }
        private void rbtBillOfLadingAll_Click(object sender, EventArgs e)
        {
            //rbtBillOfLadingAll.Checked = true;
            //rbtBillOfLading.Checked = false;
            ////ddlReceived.Text = "";
            //ddlBillOfLading.Enabled = false;

            //string recDate = selectedReceivedDate;
            //string batchId = selectedBatch;
            //string custName = selectedCustomerName;

            //if (rbtReceivedAll.Checked)
            //{
            //    recDate = "";
            //}
            //if (rbtBatchAll.Checked)
            //{
            //    batchId = "";
            //}
            //if (rbtCustomerAll.Checked)
            //{
            //    custName = "";
            //}

            //LoadData(recDate, batchId, "", "", custName);

        }
        private void rbtCustomerAll_Click(object sender, EventArgs e)
        {
            //rbtCustomerAll.Checked = true;
            //rbtCustomer.Checked = false;
            ////ddlReceived.Text = "";
            //ddlCustomer.Enabled = false;

            //string recDate = selectedReceivedDate;
            //string batchId = selectedBatch;
            //string BOL = selectedBillOfLading;

            //if (rbtReceivedAll.Checked)
            //{
            //    recDate = "";
            //}
            //if (rbtBatchAll.Checked)
            //{
            //    batchId = "";
            //}
            //if (rbtBillOfLadingAll.Checked)
            //{
            //    BOL = "";
            //}
            //LoadData(recDate, batchId, "", BOL, "");
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
        }

        private void BOL_Print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateReport_Click_1(object sender, EventArgs e)
        {
            LoadReportData();
        }

        /// <summary>
        /// LoadReportData
        /// </summary>
        private void LoadReportData()
        {
            var SPName = "BillOfLading_Report_GetAll";

            var recDate = "";
            var batchId = this.txtBatchId.Text;
            var bol = this.txtBillOfLanding.Text;
            var custName = this.txtCustomer.Text;
            var invoiceNumber = this.txtInvoiceNumber.Text;

            using (var ds = DBManager.GetDataSet_Report(SPName, recDate, batchId, invoiceNumber, bol, custName, true))
            {
                var dtBOLReport = ds.Tables[0];
                var date = DateTime.Parse(DBManager.ReportingDate);
                var fileName = "billofLadingReport" + date.ToString("MMddyyyy");

                var saveFileDialogue = new SaveFileDialog
                {
                    FileName = fileName,
                    DefaultExt = ".csv"
                };

                if (saveFileDialogue.ShowDialog() == DialogResult.OK)
                {
                    dtBOLReport.WriteToCsvFile(saveFileDialogue.FileName);
                }
            }
        }

        private void rbtReceived_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbtReceivedAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPageNumber++;
            LoadData("", "", "", "", "", this.CurrentPageNumber);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.CurrentPageNumber--;
            LoadData("", "", "", "", "", this.CurrentPageNumber);
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            this.CurrentPageNumber = 1;
            LoadData("", "", "", "", "", this.CurrentPageNumber);
        }
    }
}
