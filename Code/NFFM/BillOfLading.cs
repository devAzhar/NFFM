namespace NFFM
{
    using Base;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class BillOfLading : BaseForm
    {
        #region "Constructor"
        public BillOfLading()
        {
            DBManager.NewTruckerId = string.Empty;
            DBManager.isDataLoaded = false;

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
        
        #endregion

        #region "Private Methods"
        private void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string lineItemID = "";
            string receivingID = "";
            string billOfLading = "";
            string customerName = "";
            string shipper = "";
            string salesCode = "";
            string quantity = "";
            int rowIndex = 0;
            int columnIndex = 0;
            if (e.RowIndex > 0)
            {
                rowIndex = e.RowIndex;
            }
            if (e.ColumnIndex > 0)
            {
                columnIndex = e.ColumnIndex;
            }
            if (dataGridView1.Rows.Count > 0 && InitialDataLoaded == 1)
            {
                if (columnIndex == 3 || columnIndex == 4 || columnIndex == 5 || columnIndex == 6 || columnIndex == 9)
                {
                    receivingID = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                    if (receivingID == "")
                    {
                        receivingID = currentReceivingId;
                    }
                    lineItemID = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    billOfLading = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    customerName = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString().Trim();
                    shipper = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString().Trim();
                    salesCode = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();

                    if (columnIndex == 6)
                    {
                        var rows = dtSalesCode.Select("[Sales Code]='" + salesCode + "'");

                        if (rows.Length > 0)
                        {
                            var priceValue = 0d;
                            double.TryParse(rows[0]["Price"].ToString(), out priceValue);
                            dataGridView1.Rows[rowIndex].Cells[10].Value = priceValue;
                            dataGridView1.Rows[rowIndex].Cells[7].Value = rows[0]["Description"].ToString();
                            dataGridView1.Rows[rowIndex].Cells[8].Value = rows[0]["Unit of Measure"].ToString();
                        }
                    }

                    quantity = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                    string price = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                    float fPrice = 0f;
                    float.TryParse(price, out fPrice);
                    var iQuantity = 0;
                    int.TryParse(quantity, out iQuantity);

                    var newLineItemId = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", receivingID, lineItemID, billOfLading, customerName, shipper, salesCode, quantity, "", "", "0", "");

                    if (dataGridView1.Rows[rowIndex].Cells[11].Value.ToString() != (iQuantity * fPrice).ToString())
                    {
                        dataGridView1.Rows[rowIndex].Cells[11].Value = iQuantity * fPrice;
                        this.RecalculateTotals();
                    }

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

        protected override void HandleCellEvent(object sender, DataGridViewCellEventArgs e, bool isClick = false)
        {
            if (this.HandleCellEventFlag)
            {
                return;
            }

            try
            {

                if (e.ColumnIndex <= 0 && e.RowIndex > 0)
                {
                    var lineItemId = dataGridView1.Rows[e.RowIndex].Cells["lineitemid"].Value.ToString();

                    if (string.IsNullOrEmpty(lineItemId))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.CopyOverNewRow(dataGridView1);
                        });
                        return;
                    }
                }

                this.HandleCellEventFlag = true;

                if (e.ColumnIndex == 0 && isClick)
                {
                    string lineItemIdToDelete = dataGridView1.Rows[e.RowIndex].Cells["lineitemid"].Value.ToString();
                    if (lineItemIdToDelete != "")
                    {
                        if (MessageBox.Show("You are about to delete 1 record(s).\r\n\r\n If you click Yes, you won't be able to undo this Delete operation.\r\n Are you sure you want to delete these records?", "NFFM Bill of Lading", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
                            SqlConnection con = new SqlConnection(str);
                            SqlCommand cmd = new SqlCommand("LineItem_Delete", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("lineitemid", dataGridView1.Rows[e.RowIndex].Cells["lineitemid"].Value.ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Line item is deleted successfully.");
                            LoadData(nextReceivingId);
                        }
                    }
                }

                if (isClick)
                {
                    this.HandleCellEventFlag = false;
                    return;
                }

                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    // Bind grid cell with combobox and than bind combobox with datasource.  
                    DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                    // Check the column  cell, in which it click.  
                    if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("CustomerName"))
                    {
                        if (!(dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewComboBoxCell))
                        {
                            // On click of datagridview cell, attched combobox with this click cell of datagridview  
                            dataGridView1[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;

                            l_objGridDropbox.DataSource = new BindingSource(dtCustomers, null);
                            l_objGridDropbox.DisplayMember = "Name";
                            l_objGridDropbox.ValueMember = "Name";
                        }
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("Shipper"))
                    {
                        if (!(dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewComboBoxCell))
                        {
                            dataGridView1[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                            l_objGridDropbox.DataSource = dtShippers;
                            l_objGridDropbox.ValueMember = "Shipper";
                            l_objGridDropbox.DisplayMember = "Shipper";
                        }
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("SalesCode"))
                    {
                        if (!(dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewComboBoxCell))
                        {
                            dataGridView1[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                            l_objGridDropbox.DataSource = dtSalesCode;
                            l_objGridDropbox.ValueMember = "Sales Code";
                            l_objGridDropbox.DisplayMember = "Sales Code";
                        }
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
            String SPName = "BillOfLading_GetAll";
            //ddlCustomers.Clear();
            //ddlShippers.Clear();
            //ddlSalesCode.Clear();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = SPName;
            cmd.Parameters.AddWithValue("receivingId", receivingId);
            //cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = DBManager.GetDataSet_New(SPName, receivingId);
            // DataSet ds = DBManager.GetDataSet(SPName, cmd);
            DataTable dtTruckers = ds.Tables[0];
            DataTable dtLineItems = ds.Tables[2];
            dtCustomers = ds.Tables[3];
            dtShippers = ds.Tables[4];
            dtSalesCode = ds.Tables[5];
            currentTruckerId = "0";
            //datePickerReceived.Value = new DateTime(1900, 01, 01);
            //datePickerWeekEnding.Value = new DateTime(1900, 01, 01);

            if (ds.Tables.Count > 0)
            {
                if (items.Count == 0)
                {
                    this.LoadTruckers(ddlTruckerName, dtTruckers);
                }
                if (dtCustomers.Rows.Count > 0 && ddlCustomers.Count == 0)
                {
                    for (int i = 0; i < dtCustomers.Rows.Count; i++)
                    {
                        ddlCustomers.Add(dtCustomers.Rows[i]["customerID"].ToString(), dtCustomers.Rows[i]["Name"].ToString());
                    }
                }
                if (dtShippers.Rows.Count > 0 && ddlShippers.Count == 0)
                {
                    for (int i = 0; i < dtShippers.Rows.Count; i++)
                    {
                        ddlShippers.Add(dtShippers.Rows[i]["ShipperID"].ToString(), dtShippers.Rows[i]["Shipper"].ToString());
                    }
                }
                if (dtSalesCode.Rows.Count > 0 && ddlSalesCode.Count == 0)
                {
                    for (int i = 0; i < dtSalesCode.Rows.Count; i++)
                    {
                        ddlSalesCode.Add(dtSalesCode.Rows[i]["SalesCodeId"].ToString(), dtSalesCode.Rows[i]["Sales Code"].ToString());
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    datePickerReceived.Text = ds.Tables[1].Rows[0]["ReceivedDate"].ToString();
                    datePickerWeekEnding.Text = ds.Tables[1].Rows[0]["WeekEndingDate"].ToString();
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
            dataGridView1.Columns["BillOfLadingNumber"].Width = 120;
            dataGridView1.Columns["BillOfLadingNumber"].HeaderText = "Bill of Lading #";
            dataGridView1.Columns["CustomerName"].Width = 199;
            dataGridView1.Columns["CustomerName"].HeaderText = "Co-Op Member";
            dataGridView1.Columns["SalesCode"].Width = 100;
            dataGridView1.Columns["SalesCode"].HeaderText = "Sales Code";
            dataGridView1.Columns["UnitOfMeasure"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["UnitOfMeasure"].Width = 120;
            dataGridView1.Columns["Qty"].Width = 50;
            dataGridView1.Columns["Price"].Width = 50;
            dataGridView1.Columns["Price"].ValueType = typeof(double);

            dataGridView1.Columns["Ext"].Width = 50;

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
            dataGridView1.Columns["Ext"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DBManager.isDataLoaded = true;
            //dataGridView1.AllowUserToAddRows = true;

            dataGridView1.Columns["BillOfLadingNumber"].ReadOnly = false;
            dataGridView1.Columns["CustomerName"].ReadOnly = false;
            dataGridView1.Columns["Shipper"].ReadOnly = false;
            dataGridView1.Columns["SalesCode"].ReadOnly = false;
            dataGridView1.Columns["Qty"].ReadOnly = false;

            dataGridView1.Columns["Description"].ReadOnly = true;
            dataGridView1.Columns["UnitOfMeasure"].ReadOnly = true;
            dataGridView1.Columns["Price"].ReadOnly = true;
            dataGridView1.Columns["Ext"].ReadOnly = true;

            dataGridView1.Columns["BillOfLadingNumber"].Width = 135;
            dataGridView1.Columns["Shipper"].Width = 123;
            dataGridView1.Columns["SalesCode"].Width = 115;
            dataGridView1.Columns["UnitOfMeasure"].Width = 150;

            label1.Text = "Click a heading to sort the data.";
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
            currentReceivingId = "0";
            currentTruckerId = "0";
            ddlTruckerName.Text = "";
            txtTruckingTotal.Text = "";
            IsNewRecord = 1;
            LoadData(-1);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            OnCellValueChanged(sender, e);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            LoadData(previousReceivingId);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            LoadData(firstReceivingId);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadData(nextReceivingId);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
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
            }
            else if (currentTruckerId != truckerId && truckerId != "1" && InitialDataLoaded == 1 && IsNewRecord == 1)
            {
                IsNewRecord = 0;
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", datePickerReceived.Text, datePickerWeekEnding.Text, truckerId, txtBatchId.Text);
                LoadData(0);
            }
        }

        private void txtBatchId_Leave(object sender, EventArgs e)
        {
            if (InitialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", "", "", "0", txtBatchId.Text);
            }
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
            if (MessageBox.Show("You are about to delete 1 record(s).\r\n\r\n If you click Yes, you won't be able to undo this Delete operation.\r\n Are you sure you want to delete these records?", "NFFM Bill of Lading", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("BillOfLading_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ReceivingId", currentReceivingId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //DBManager.isDataLoaded = false;
                MessageBox.Show("Bill of Lading is deleted successfully.");
                LoadData(nextReceivingId);
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
    }
}