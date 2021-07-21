namespace NFFM
{
    using Base;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class BillOfLading : BaseForm
    {
        #region "Constructor"
        public BillOfLading()
        {
            DBManager.NewTruckerId = string.Empty;
            DBManager.isDataLoaded = false;
            DBManager.currentRecordId = 0;
            InitializeComponent();
            this.Text = "NFFM";
        }
        #endregion

        #region "Private Members"
        private string currentReceivingId = "0";
        private string currentTruckerId = "0";
        private int previousReceivingId = 0;
        private int firstReceivingId = 0;
        private int nextReceivingId = 0;
        private int lastReceivingId = 0;
        private int pagerClicked = 0;

        #endregion

        #region "Private Methods"
        protected override void OnCellValueChanged(int eventRowIndex, int eventColumnIndex = 3, bool ignoreDBSave = false)
        {
            if (DBManager.CopyInProgress)
            {
                return;
            }

            var rowIndex = 0;
            var columnIndex = 0;

            if (eventRowIndex > 0)
            {
                rowIndex = eventRowIndex;
            }

            if (eventColumnIndex > 0)
            {
                columnIndex = eventColumnIndex;
            }

            if (dataGridView1.Rows.Count > 0 && InitialDataLoaded == 1)
            {
                if (columnIndex == 3 || columnIndex == 4 || columnIndex == 5 || columnIndex == 6 || columnIndex == 9)
                {
                    var receivingID = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();

                    if (receivingID == "")
                    {
                        receivingID = currentReceivingId;
                    }

                    var salesCode = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString().Trim();
                    var customerName = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString().Trim();
                    var shipper = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString().Trim();

                    if (columnIndex == 4)
                    {
                        var rows = Customers.Select("[Name]='" + DBManager.SqlSafe(customerName) + "'");

                        if (rows.Length > 0)
                        {
                            customerName = rows[0]["Name"].ToString().Trim();
                        }
                        else
                        {
                            customerName = string.Empty;
                        }

                        if (customerName != dataGridView1.Rows[rowIndex].Cells[4].Value.ToString().Trim())
                        {
                            dataGridView1.Rows[rowIndex].Cells[4].Value = customerName;
                            return;
                        }
                    }

                    if (columnIndex == 5)
                    {
                        var rows = Shippers.Select("[Shipper]='" + DBManager.SqlSafe(shipper) + "'");

                        if (rows.Length > 0)
                        {
                            shipper = rows[0]["Shipper"].ToString().Trim();
                        }
                        else
                        {
                            shipper = string.Empty;
                        }

                        if (shipper != dataGridView1.Rows[rowIndex].Cells[5].Value.ToString().Trim())
                        {
                            dataGridView1.Rows[rowIndex].Cells[5].Value = shipper;
                            return;
                        }
                    }

                    if (columnIndex == 6)
                    {
                        salesCode = salesCode.ToUpperInvariant();
                        var rows = SalesCode.Select("[Sales Code]='" + salesCode + "'");

                        if (rows.Length > 0)
                        {
                            var row = rows[0];
                            var priceValue = 0d;
                            double.TryParse(row["Price"].ToString(), out priceValue);
                            dataGridView1.Rows[rowIndex].Cells[7].Value = row["Description"].ToString();
                            dataGridView1.Rows[rowIndex].Cells[8].Value = row["Unit of Measure"].ToString();
                            dataGridView1.Rows[rowIndex].Cells[10].Value = priceValue;
                        }
                        else
                        {
                            salesCode = "";
                            dataGridView1.Rows[rowIndex].Cells[7].Value = string.Empty;
                            dataGridView1.Rows[rowIndex].Cells[8].Value = string.Empty;
                            dataGridView1.Rows[rowIndex].Cells[10].Value = "0";
                        }

                        if (dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString() != salesCode)
                        {
                            dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = salesCode;
                            return;
                        }
                    }

                    var lineItemID = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    var billOfLading = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    var quantity = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();

                    dataGridView1.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
                    dataGridView1.Rows[rowIndex].Cells[4].Style.BackColor = Color.White;
                    dataGridView1.Rows[rowIndex].Cells[5].Style.BackColor = Color.White;
                    dataGridView1.Rows[rowIndex].Cells[6].Style.BackColor = Color.White;
                    dataGridView1.Rows[rowIndex].Cells[9].Style.BackColor = Color.White;

                    var incompleteFlag = false;
                    var currentRowFlag = false;

                    if (rowIndex >= 0)
                    {
                        var previousRowIndex = rowIndex - 1;

                        if (previousRowIndex >= 0)
                        {
                            if (string.IsNullOrEmpty(dataGridView1.Rows[previousRowIndex].Cells[3].Value.ToString()))
                            {
                                dataGridView1.Rows[previousRowIndex].Cells[3].Style.BackColor = Color.Red;
                                incompleteFlag = true;
                            }
                            else if (string.IsNullOrEmpty(dataGridView1.Rows[previousRowIndex].Cells[4].Value.ToString()))
                            {
                                dataGridView1.Rows[previousRowIndex].Cells[4].Style.BackColor = Color.Red;
                                incompleteFlag = true;
                            }
                            else if (string.IsNullOrEmpty(dataGridView1.Rows[previousRowIndex].Cells[5].Value.ToString()))
                            {
                                dataGridView1.Rows[previousRowIndex].Cells[5].Style.BackColor = Color.Red;
                                incompleteFlag = true;
                            }
                            else if (string.IsNullOrEmpty(dataGridView1.Rows[previousRowIndex].Cells[6].Value.ToString()))
                            {
                                dataGridView1.Rows[previousRowIndex].Cells[6].Style.BackColor = Color.Red;
                                incompleteFlag = true;
                            }
                            else if (string.IsNullOrEmpty(dataGridView1.Rows[previousRowIndex].Cells[9].Value.ToString()) || dataGridView1.Rows[previousRowIndex].Cells[9].Value.ToString() == "0")
                            {
                                dataGridView1.Rows[previousRowIndex].Cells[9].Style.BackColor = Color.Red;
                                incompleteFlag = true;
                            }
                        }

                        if (string.IsNullOrEmpty(dataGridView1.Rows[rowIndex].Cells[3].Value.ToString()))
                        {
                            dataGridView1.Rows[rowIndex].Cells[3].Style.BackColor = Color.Red;
                            currentRowFlag = true;
                        }

                        if (string.IsNullOrEmpty(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString()))
                        {
                            dataGridView1.Rows[rowIndex].Cells[4].Style.BackColor = Color.Red;
                            currentRowFlag = true;
                        }

                        if (string.IsNullOrEmpty(dataGridView1.Rows[rowIndex].Cells[5].Value.ToString()))
                        {
                            dataGridView1.Rows[rowIndex].Cells[5].Style.BackColor = Color.Red;
                            currentRowFlag = true;
                        }

                        if (string.IsNullOrEmpty(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString()))
                        {
                            dataGridView1.Rows[rowIndex].Cells[6].Style.BackColor = Color.Red;
                            currentRowFlag = true;
                        }

                        if (string.IsNullOrEmpty(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString()) || dataGridView1.Rows[rowIndex].Cells[9].Value.ToString() == "0")
                        {
                            dataGridView1.Rows[rowIndex].Cells[9].Style.BackColor = Color.Red;
                            currentRowFlag = true;
                        }

                        if (incompleteFlag || currentRowFlag)
                        {
                            if (!this.IsAlertShown)
                            {
                                if (incompleteFlag)
                                {
                                    this.IsAlertShown = true;
                                    MessageBox.Show("Bill of lading #, Customer name, Shipper, Sales Code & quantity columns are mandatory, kindly fill these columns of above row.");
                                }

                                return;
                            }
                        }
                    }

                    //if (string.IsNullOrEmpty(billOfLading))
                    //{
                    //    dataGridView1.Rows[rowIndex].Cells[3].Style.BackColor = Color.Red;
                    //}
                    //else if (string.IsNullOrEmpty(customerName))
                    //{
                    //    dataGridView1.Rows[rowIndex].Cells[4].Style.BackColor = Color.Red;
                    //    //dataGridView1.Rows[rowIndex].Cells[4].Style.ForeColor = Color.Yellow;
                    //}
                    //else if (string.IsNullOrEmpty(shipper))
                    //{
                    //    dataGridView1.Rows[rowIndex].Cells[5].Style.BackColor = Color.Red;
                    //}
                    //else if (string.IsNullOrEmpty(salesCode)) {
                    //    dataGridView1.Rows[rowIndex].Cells[6].Style.BackColor = Color.Red;
                    //}
                    //else if (string.IsNullOrEmpty(quantity))
                    //{
                    //    dataGridView1.Rows[rowIndex].Cells[9].Style.BackColor = Color.Red;
                    //}

                    //dataGridView1.Columns["BillOfLadingNumber"].DefaultCellStyle.BackColor = Color.Red;

                    string price = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                    float fPrice = 0f;
                    float.TryParse(price, out fPrice);
                    var iQuantity = 0;
                    int.TryParse(quantity, out iQuantity);

                    if (dataGridView1.Rows[rowIndex].Cells[11].Value.ToString() != (iQuantity * fPrice).ToString())
                    {
                        dataGridView1.Rows[rowIndex].Cells[11].Value = iQuantity * fPrice;
                        this.RecalculateTotals();
                    }

                    if (!ignoreDBSave)
                    {
                        var newLineItemId = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", receivingID, lineItemID, billOfLading, customerName, shipper, salesCode, quantity, "", "", "0", "");

                        if (string.IsNullOrEmpty(lineItemID))
                        {
                            dataGridView1.Rows[rowIndex].Cells[2].Value = newLineItemId;
                        }

                        if (newLineItemId < 1)
                        {
                            MessageBox.Show("Error Occurred.");
                        }
                    }
                }
            }

            // row = dataGridView1.Rows[c];
            //a = Convert.ToInt32(row.Cells[b].Value);
            //lineItemId = e.RowIndex;
            //DataGridViewRow row = dataGridView1.Rows[lineItemId];
            //currentReceivingId = Convert.ToInt32(row.Cells[0].Value);
            //lineItemId = Convert.ToInt32(row.Cells[1].Value);
        }
        #endregion

        #region "Implementation of abstract methods"
        protected override ComboBox ComboBoxTruckerName
        {
            get
            {
                return this.ddlTruckerName;
            }
        }

        private void HandleNewRow(int rowIndex)
        {
            var lineItemId = dataGridView1.Rows[rowIndex].Cells["lineitemid"].Value.ToString();

            if (string.IsNullOrEmpty(lineItemId))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.CopyOverNewRow(dataGridView1);
                });
                return;
            }
        }
        private void HandleDelete(int rowIndex)
        {
            string lineItemIdToDelete = dataGridView1.Rows[rowIndex].Cells["lineitemid"].Value.ToString();

            if (lineItemIdToDelete != "")
            {
                if (MessageBox.Show("You are about to delete 1 record.\r\n\r\n If you click Yes, you won't be able to undo this Delete operation.\r\n Are you sure you want to delete these records?", "NFFM Bill of Lading", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(Constants.Constants.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("LineItem_Delete", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("lineitemid", lineItemIdToDelete);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            // MessageBox.Show("Line item is deleted successfully.");
                            LoadData(DBManager.currentRecordId);
                        }
                    }
                }
            }
        }

        protected override void HandleCellEvent(object sender, DataGridViewCellEventArgs e, bool isClick = false)
        {
            if (this.HandleCellEventFlag)
            {
                return;
            }

            try
            {
                if (e.ColumnIndex <= 3 && e.RowIndex > 0)
                {
                    HandleNewRow(e.RowIndex);
                    return;
                }

                this.HandleCellEventFlag = true;

                if (e.ColumnIndex == 0 && isClick)
                {
                    HandleDelete(e.RowIndex);
                }

                if (isClick)
                {
                    this.HandleCellEventFlag = false;
                    return;
                }

                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    // Check the column  cell, in which it click.  
                    if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("Description"))
                    {
                        var quantityColumnIndex = 9;
                        var quantityCell = dataGridView1.Rows[e.RowIndex].Cells[quantityColumnIndex];
                    }
                }
            }
            catch (Exception exp)
            {
            }

            this.HandleCellEventFlag = false;
        }

        protected override void LoadData(int receivingId)
        {
            DBManager.currentRecordId = receivingId;
            var storedProcedureName = "BillOfLading_GetAll";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("receivingId", receivingId);
            DataSet ds = DBManager.GetDataSet_New(storedProcedureName, receivingId);
            var dtTruckers = ds.Tables[0];
            var dtLineItems = ds.Tables[2];
            Customers = ds.Tables[3];
            Shippers = ds.Tables[4];
            SalesCode = ds.Tables[5];
            currentTruckerId = "0";

            if (ds.Tables.Count > 0)
            {
                if (ItemsDictionary.Count == 0)
                {
                    this.LoadTruckers(ddlTruckerName, dtTruckers);
                }
                if (Customers.Rows.Count > 0 && CustomersDictionary.Count == 0)
                {
                    for (int i = 0; i < Customers.Rows.Count; i++)
                    {
                        CustomersDictionary.Add(Customers.Rows[i]["customerID"].ToString(), Customers.Rows[i]["Name"].ToString());
                    }
                }
                if (Shippers.Rows.Count > 0 && ShippersDictionary.Count == 0)
                {
                    for (int i = 0; i < Shippers.Rows.Count; i++)
                    {
                        ShippersDictionary.Add(Shippers.Rows[i]["ShipperID"].ToString(), Shippers.Rows[i]["Shipper"].ToString());
                    }
                }
                if (SalesCode.Rows.Count > 0 && SalesCodeDictionary.Count == 0)
                {
                    for (int i = 0; i < SalesCode.Rows.Count; i++)
                    {
                        SalesCodeDictionary.Add(SalesCode.Rows[i]["SalesCodeId"].ToString(), SalesCode.Rows[i]["Sales Code"].ToString());
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["ReceivedDate"].ToString() == "1/1/1900 12:00:00 AM")
                    {
                        DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
                        DateTime startingDate = DateTime.Today;

                        while (startingDate.DayOfWeek != weekStart)
                            startingDate = startingDate.AddDays(-1);

                        DateTime previousWeekStart = startingDate.AddDays(-7);
                        DateTime previousWeekEnd = startingDate.AddDays(-3);
                        txtBatchId.Text = "";
                        datePickerReceived.Text = previousWeekStart.ToShortDateString();
                        datePickerWeekEnding.Text = previousWeekEnd.ToShortDateString();
                    }
                    else
                    {
                        datePickerReceived.Text = ds.Tables[1].Rows[0]["ReceivedDate"].ToString();
                        datePickerWeekEnding.Text = ds.Tables[1].Rows[0]["WeekEndingDate"].ToString();
                    }
                    txtBatchId.Text = ds.Tables[1].Rows[0]["BatchID"].ToString();
                    ddlTruckerName.Text = ds.Tables[1].Rows[0]["Trucker"].ToString();
                    currentTruckerId = ds.Tables[1].Rows[0]["TruckerID"].ToString();
                    txtRecords.ReadOnly = true;
                    txtRecords.Text = ds.Tables[1].Rows[0]["CurrentRecord"].ToString() + " of " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                    currentReceivingId = ds.Tables[1].Rows[0]["receivingId"].ToString();
                    previousReceivingId = Convert.ToInt32(ds.Tables[1].Rows[0]["previousReceivingId"]);
                    firstReceivingId = Convert.ToInt32(ds.Tables[1].Rows[0]["firstReceivingId"]);
                    nextReceivingId = Convert.ToInt32(ds.Tables[1].Rows[0]["nextReceivingId"]);
                    lastReceivingId = Convert.ToInt32(ds.Tables[1].Rows[0]["lastReceivingId"]);
                    if (nextReceivingId.ToString() == "0")
                    {
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                    }
                    else
                    {
                        btnNext.Enabled = true;
                        btnLast.Enabled = true;
                    }
                    if (previousReceivingId.ToString() == "0")
                    {
                        btnPrevious.Enabled = false;
                        btnFirst.Enabled = false;
                    }
                    else
                    {
                        btnPrevious.Enabled = true;
                        btnFirst.Enabled = true;
                    }
                    DBManager.isDataLoaded = true;
                }
                if (dtLineItems.Rows.Count > 0)
                {

                    BindLineItems(dtLineItems);
                }
                else
                {
                    BindLineItems(ds.Tables[6]);
                }
            }
        }

        protected override void BindLineItems(DataTable dtLineItems)
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

            dataGridView1.Columns["receivingId"].Visible = false;
            dataGridView1.Columns["lineitemId"].Visible = false;
            dataGridView1.Columns["Action"].Width = 30;
            dataGridView1.Columns["BillOfLadingNumber"].Width = 155;
            dataGridView1.Columns["BillOfLadingNumber"].HeaderText = "Bill of Lading #";
            dataGridView1.Columns["CustomerName"].Width = 320;
            dataGridView1.Columns["CustomerName"].HeaderText = "Customer";
            dataGridView1.Columns["Shipper"].Width = 150;
            dataGridView1.Columns["SalesCode"].Width = 130;
            dataGridView1.Columns["SalesCode"].HeaderText = "Sales Code";
            dataGridView1.Columns["Description"].Width = 145;
            dataGridView1.Columns["UnitOfMeasure"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["UnitOfMeasure"].Width = 250;
            dataGridView1.Columns["Qty"].Width = 100;
            dataGridView1.Columns["Price"].Width = 100;
            dataGridView1.Columns["Price"].ValueType = typeof(double);

            dataGridView1.Columns["Ext"].Width = 120;

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

            dataGridView1.Columns["BillOfLadingNumber"].ReadOnly = false;
            dataGridView1.Columns["CustomerName"].ReadOnly = false;
            dataGridView1.Columns["Shipper"].ReadOnly = false;
            dataGridView1.Columns["SalesCode"].ReadOnly = false;
            dataGridView1.Columns["Qty"].ReadOnly = false;

            dataGridView1.Columns["Description"].ReadOnly = true;
            dataGridView1.Columns["UnitOfMeasure"].ReadOnly = true;
            dataGridView1.Columns["Price"].ReadOnly = true;
            dataGridView1.Columns["Ext"].ReadOnly = true;

            label1.Text = "";
            label1.Font = new Font(label1.Font, FontStyle.Regular);
            label1.Font = new System.Drawing.Font(label1.Font.FontFamily.Name, 10);
            label1.BackColor = Color.Transparent;

            if (dtLineItems.Rows[0]["receivingId"].ToString() == "-1")
            {
                label1.Text = "Select a Trucker Name to continue.";
                label1.Font = new Font(label1.Font, FontStyle.Bold);
                label1.Font = new System.Drawing.Font(label1.Font.FontFamily.Name, 10);
                label1.BackColor = Color.Red;
                dataGridView1.Columns["BillOfLadingNumber"].ReadOnly = true;
                dataGridView1.Columns["CustomerName"].ReadOnly = true;
                dataGridView1.Columns["Shipper"].ReadOnly = true;
                dataGridView1.Columns["SalesCode"].ReadOnly = true;
                dataGridView1.Columns["Qty"].ReadOnly = true;
                pagerClicked = 0;
            }
            else
            {
                //Foccus to the Bill of Lading
                //SendKeys.SendWait("{TAB}");
            }
        }

        protected override void RecalculateTotals()
        {
            var total = 0d;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[11].Value != null)
                {
                    var rowTotal = 0d;
                    var rowTotalValue = row.Cells[11].Value.ToString().Replace("$", string.Empty);

                    double.TryParse(rowTotalValue, out rowTotal);
                    total += rowTotal;
                }
            }

            txtTruckingTotal.Text = "$" + Math.Round(total, 2);
        }
        #endregion

        #region "Event Handlers"
        protected void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Handle cell skip...
            if (dataGridView1.CurrentRow.Cells[e.ColumnIndex].ReadOnly && Control.ModifierKeys != Keys.Shift && e.ColumnIndex > 1)
            {
                SendKeys.Send("{tab}");
                return;
            }

            this.HandleCellEvent(sender, e);
        }

        protected void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        protected void Form1_Activated(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            if (!string.IsNullOrEmpty(DBManager.NewTruckerId))
            {
                var data = DBManager.GetDataTable("Truckers_GetAll");
                this.LoadTruckers(this.ComboBoxTruckerName, data, DBManager.NewTruckerId);
                DBManager.NewTruckerId = string.Empty;
                return;
            }

            if (DBManager.isDataLoaded == false)
            {
                this.LoadData(DBManager.currentRecordId);
                this.InitialDataLoaded = 1;
            }
        }

        protected void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.HandleCellEvent(sender, e, true);
        }

        protected void comboBoxGeneral_Enter(object sender, EventArgs e)
        {
            OnComboBoxGeneralEnter(sender);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            DateTime previousWeekStart = startingDate.AddDays(-7);
            DateTime previousWeekEnd = startingDate.AddDays(-3);
            txtBatchId.Text = "";
            datePickerReceived.Text = previousWeekStart.ToShortDateString();
            datePickerWeekEnding.Text = previousWeekEnd.ToShortDateString();
            currentReceivingId = "0";
            currentTruckerId = "0";
            ddlTruckerName.Text = "";
            txtTruckingTotal.Text = "";
            IsNewRecord = 1;
            LoadData(-1);
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Task.Delay(100).ContinueWith(t => OnCellValueChanged(e.RowIndex));
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            OnCellValueChanged(e.RowIndex, e.ColumnIndex, true);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pagerClicked = 1;
            LoadData(previousReceivingId);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pagerClicked = 1;
            LoadData(firstReceivingId);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pagerClicked = 1;
            LoadData(nextReceivingId);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pagerClicked = 1;
            LoadData(lastReceivingId);
        }

        private void ddlTruckerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string truckerId = ((KeyValuePair<string, string>)ddlTruckerName.SelectedItem).Key;

            if (truckerId == "-1" && FormInitialized)
            {
                Trucker_AddUpdate add = new Trucker_AddUpdate();
                add.ShowDialog();
                return;
            }

            string truckerName = ((KeyValuePair<string, string>)ddlTruckerName.SelectedItem).Value;
            if (currentTruckerId != truckerId && currentTruckerId != "0" && InitialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", "", "", truckerId, "");
                //SendKeys.SendWait("{TAB}"); //Foccus to the Bill of Lading
            }
            else if (currentTruckerId != truckerId && truckerId != "1" && InitialDataLoaded == 1 && IsNewRecord == 1 && pagerClicked == 0)
            {
                IsNewRecord = 0;
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", datePickerReceived.Text, datePickerWeekEnding.Text, truckerId, txtBatchId.Text);
                LoadData(0);
            }
        }

        private void OntxtBatchId_Leave()
        {
            if (InitialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", "", "", "0", txtBatchId.Text);
            }
        }

        private void txtBatchId_Leave(object sender, EventArgs e)
        {
            OntxtBatchId_Leave();
        }

        private void datePickerReceived_Leave(object sender, EventArgs e)
        {
            if (InitialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", datePickerReceived.Text, datePickerWeekEnding.Text, "0", "");
            }
        }

        private void datePickerWeekEnding_Leave(object sender, EventArgs e)
        {
            if (InitialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", datePickerReceived.Text, datePickerWeekEnding.Text, "0", "");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to delete 1 record.\r\n\r\nIf you click Yes, you won't be able to undo this Delete operation.\r\nAre you sure you want to delete these records?", "NFFM Bill of Lading", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var connection = new SqlConnection(Constants.Constants.ConnectionString))
                {
                    using (var command = new SqlCommand("BillOfLading_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("ReceivingId", currentReceivingId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Bill of Lading is deleted successfully.");
                        LoadData(nextReceivingId);
                    }
                }
            }
        }

        private void datePickerReceived_ValueChanged(object sender, EventArgs e)
        {
            if (datePickerReceived.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                datePickerWeekEnding.Value = datePickerReceived.Value.AddDays(5);
            }
            else if (datePickerReceived.Value.DayOfWeek == DayOfWeek.Monday)
            {
                datePickerWeekEnding.Value = datePickerReceived.Value.AddDays(4);
            }
            else if (datePickerReceived.Value.DayOfWeek == DayOfWeek.Tuesday)
            {
                datePickerWeekEnding.Value = datePickerReceived.Value.AddDays(3);
            }
            else if (datePickerReceived.Value.DayOfWeek == DayOfWeek.Wednesday)
            {
                datePickerWeekEnding.Value = datePickerReceived.Value.AddDays(2);
            }
            else if (datePickerReceived.Value.DayOfWeek == DayOfWeek.Thursday)
            {
                datePickerWeekEnding.Value = datePickerReceived.Value.AddDays(1);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            OnDataGridViewKeyDown(dataGridView1, e);
        }
        #endregion

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Application.DoEvents();
        }

        #region "Additional Buttons"
        private void btnAddShipper_Click(object sender, EventArgs e)
        {
            Shipper_AddUpdate add = new Shipper_AddUpdate();
            add.ShowDialog();
            LoadData(DBManager.currentRecordId);
            // return;
        }

        private void btnCustomer_click(object sender, EventArgs e)
        {
            Customers_AddUpdate add = new Customers_AddUpdate();
            add.ShowDialog();
            LoadData(DBManager.currentRecordId);
        }

        private void btnSalesCode_click(object sender, EventArgs e)
        {
            SalesCode_AddUpdate add = new SalesCode_AddUpdate();
            add.ShowDialog();
            LoadData(DBManager.currentRecordId);
        }
        #endregion

        private void txtBatchId_KeyUp(object sender, KeyEventArgs e)
        {
            OntxtBatchId_KeyUp(dataGridView1, e);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            OndataGridView1_EditingControlShowing(dataGridView1, e);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var BOLReport = new BillOfLading_Report();
            var isFormOpen = IsAlreadyOpen(typeof(BillOfLading_Report));

            if (!isFormOpen)
            {
                BOLReport.Show();
            }
        }
    }
}