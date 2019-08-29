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
    public partial class BillOfLading : Form
    {
        private bool FormInitialized = false;

        public BillOfLading()
        {
            DBManager.NewTruckerId = string.Empty;
            DBManager.isDataLoaded = false;

            InitializeComponent();
            this.Text = "NFFM";
        }
        int initialDataLoaded = 0;
        int isButtonClicked = 0;
        string currentReceivingId = "0";
        string currentTruckerId = "0";
        int previousReceivingId = 0;
        int firstReceivingId = 0;
        int nextReceivingId = 0;
        int lastReceivingId = 0;
        int IsNewRecord = 0;
        int lineItemId;
        DataGridViewRow row;
        Dictionary<string, string> ddlCustomers = new Dictionary<string, string>();
        Dictionary<string, string> ddlShippers = new Dictionary<string, string>();
        Dictionary<string, string> ddlSalesCode = new Dictionary<string, string>();
        Dictionary<string, string> items = new Dictionary<string, string>();
        DataTable dtCustomers;
        DataTable dtShippers;
        DataTable dtSalesCode;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentReceivingId = "0";
            currentTruckerId = "0";
            //datePickerReceived.Value = new DateTime(2010, 01, 01);
            //datePickerWeekEnding.Value = new DateTime(2010, 01, 01);
            //txtBatchId.Text = "";
            ddlTruckerName.Text = "";
            txtTruckingTotal.Text = "";
            //DataTable dataTable = (DataTable)dataGridView1.DataSource;
            //DataRow drToAdd = dataTable.NewRow();

            //drToAdd["Shipper"] = "Value1";
            //drToAdd["SalesCode"] = "Value2";

            //dataTable.Rows.Add(drToAdd);
            //dataTable.AcceptChanges();
            //dataGridView1.DataSource = dataTable;
            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.Ta.Text = "No Data to display"
            IsNewRecord = 1;
            //foreach (DataGridViewRow item in this.dataGridView1.Rows)
            //{
            //    dataGridView1.Rows.RemoveAt(item.Index);
            //}
            LoadData(-1);
        }

        private void LoadTruckers(DataTable dtTruckers, string selectedValue = "")
        {
            FormInitialized = false;
            if (dtTruckers.Rows.Count > 0)
            {
                items.Clear();

                items.Add("-1", "<<Add New Trucker>>");

                for (int i = 0; i < dtTruckers.Rows.Count; i++)
                {
                    items.Add(dtTruckers.Rows[i]["truckerID"].ToString(), dtTruckers.Rows[i]["Trucker"].ToString());
                }
                ddlTruckerName.DataSource = new BindingSource(items, null);
                ddlTruckerName.DisplayMember = "Value";
                ddlTruckerName.ValueMember = "Key";

                if(!string.IsNullOrEmpty(selectedValue))
                {
                    ddlTruckerName.SelectedValue = selectedValue;
                }

                FormInitialized = true;
            }
        }
        public void LoadData(int receivingId)
        {
            String SPName = "BillOfLading_GetAll";
            //ddlCustomers.Clear();
            //ddlShippers.Clear();
            //ddlSalesCode.Clear();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = SPName;
            cmd.Parameters.Add("receivingId", receivingId);
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
                    LoadTruckers(dtTruckers);
                    //FormInitialized = false;
                    //if (dtTruckers.Rows.Count > 0)
                    //{
                    //    items.Add("-1", "<<Add New Trucker>>");

                    //    for (int i = 0; i < dtTruckers.Rows.Count; i++)
                    //    {
                    //        items.Add(dtTruckers.Rows[i]["truckerID"].ToString(), dtTruckers.Rows[i]["Trucker"].ToString());
                    //    }
                    //    ddlTruckerName.DataSource = new BindingSource(items, null);
                    //    ddlTruckerName.DisplayMember = "Value";
                    //    ddlTruckerName.ValueMember = "Key";
                    //    FormInitialized = true;
                    //}
                }
                if (dtCustomers.Rows.Count > 0 && ddlCustomers.Count == 0)
                {
                    for (int i = 0; i < dtCustomers.Rows.Count; i++)
                    {
                        ddlCustomers.Add(dtCustomers.Rows[i]["customerID"].ToString(), dtCustomers.Rows[i]["Name"].ToString());
                    }
                    //ddlTruckerName.DataSource = new BindingSource(items, null);
                    //ddlTruckerName.DisplayMember = "Value";
                    //ddlTruckerName.ValueMember = "Key";
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
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DBManager.NewTruckerId))
            {
                var data = DBManager.GetDataTable("Truckers_GetAll");
                LoadTruckers(data, DBManager.NewTruckerId);
                DBManager.NewTruckerId = string.Empty;
                //ddlTruckerName.SelectedValue = DBManager.NewTruckerId;
                return;
            }

            if (DBManager.isDataLoaded == false)
            {
                LoadData(0);
                initialDataLoaded = 1;
            }
            // LoadData();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
            int rowsEffected = 0;
            if (e.RowIndex > 0)
            {
                rowIndex = e.RowIndex;
            }
            if (e.ColumnIndex > 0)
            {
                columnIndex = e.ColumnIndex;
            }
            if (dataGridView1.Rows.Count > 0 && initialDataLoaded == 1)
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
                    //ddlCustomers.TryGetValue(customerName, out customerName);

                    shipper = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString().Trim();
                    salesCode = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                    quantity = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                    string price = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                    dataGridView1.Rows[rowIndex].Cells[11].Value = int.Parse(quantity) * float.Parse(price);
                    rowsEffected = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", receivingID, lineItemID, billOfLading, customerName, shipper, salesCode, quantity, "", "", "0", "");
                    //DBManager.isDataLoaded = false;
                    //LoadData(Convert.ToInt32(receivingID));
                    if (rowsEffected < 1)
                    {
                        MessageBox.Show("Error Occurred.");
                    }
                    //else
                    //{
                    //    MessageBox.Show("Row is updated successfully.");
                    //}
                }
            }

            // row = dataGridView1.Rows[c];
            //a = Convert.ToInt32(row.Cells[b].Value);
            //lineItemId = e.RowIndex;
            //DataGridViewRow row = dataGridView1.Rows[lineItemId];
            //currentReceivingId = Convert.ToInt32(row.Cells[0].Value);
            //lineItemId = Convert.ToInt32(row.Cells[1].Value);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //currentTruckerId = "0";
            isButtonClicked = 1;
            LoadData(previousReceivingId);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //currentTruckerId = "0";
            isButtonClicked = 1;
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
            if (currentTruckerId != truckerId && currentTruckerId != "0" && initialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", "", "", truckerId, "");
            }
            else if (currentTruckerId != truckerId && truckerId != "1" && initialDataLoaded == 1 && IsNewRecord == 1)
            {
                IsNewRecord = 0;
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", datePickerReceived.Text, datePickerWeekEnding.Text, truckerId, txtBatchId.Text);
                LoadData(0);
            }
        }

        private void txtBatchId_Leave(object sender, EventArgs e)
        {
            if (initialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", "", "", "0", txtBatchId.Text);
            }
        }

        private void datePickerReceived_Leave(object sender, EventArgs e)
        {
            if (initialDataLoaded == 1 && IsNewRecord == 0)
            {
                int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", currentReceivingId, "", "", "", "", "", "", datePickerReceived.Text, datePickerWeekEnding.Text, "0", "");
            }
        }
        private void datePickerWeekEnding_Leave(object sender, EventArgs e)
        {
            if (initialDataLoaded == 1 && IsNewRecord == 0)
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
                cmd.Parameters.Add("ReceivingId", currentReceivingId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //DBManager.isDataLoaded = false;
                MessageBox.Show("Bill of Lading is deleted successfully.");
                isButtonClicked = 1;
                LoadData(nextReceivingId);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
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
                        cmd.Parameters.Add("lineitemid", dataGridView1.Rows[e.RowIndex].Cells["lineitemid"].Value.ToString());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //DBManager.isDataLoaded = false;
                        MessageBox.Show("Line item is deleted successfully.");
                        isButtonClicked = 1;
                        LoadData(nextReceivingId);
                    }
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();

                // Check the column  cell, in which it click.  
                if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("CustomerName"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    dataGridView1[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    //l_objGridDropbox.DataSource = dtCustomers; // Bind combobox with datasource.  

                    l_objGridDropbox.DataSource = new BindingSource(dtCustomers, null);
                    l_objGridDropbox.DisplayMember = "Name";
                    l_objGridDropbox.ValueMember = "Name";

                    //l_objGridDropbox.ValueMember = "Name";
                    //l_objGridDropbox.DisplayMember = "Name";

                }

                if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("Shipper"))
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = dtShippers;
                    l_objGridDropbox.ValueMember = "Shipper";
                    l_objGridDropbox.DisplayMember = "Shipper";
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("SalesCode"))
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = dtSalesCode;
                    l_objGridDropbox.ValueMember = "Sales Code";
                    l_objGridDropbox.DisplayMember = "Sales Code";
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
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
