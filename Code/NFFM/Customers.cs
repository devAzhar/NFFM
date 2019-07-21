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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            this.Text = "NFFM";
            DBManager.isDataLoaded = false;
        }
        int selectedRow;
        
       
        public void LoadData()
        {
            String SPName = "Customers_GetAll";
            DataTable dt = DBManager.GetDataTable(SPName);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["CustomerID"].Visible = false;
            dataGridView1.Columns["coOp Member"].ReadOnly = true;
            //dataGridView1.BackgroundColor = Color.Red;
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns["Customer No"].Width = 120;
            dataGridView1.Columns["Name"].Width = 213;
            dataGridView1.Columns["CoOp Member"].Width = 120;
            dataGridView1.Columns["Price"].Width = 60;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DBManager.isDataLoaded = true;
            //txtCustNo.Text = "123";
            //txtName.Text = "TestCust";
            //txtFFtier.Text = "3";
            //chkCoop.Checked = false;
            //txtPrice.Text = "1.2";

            //String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            //SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand("Customers_Add", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("CustomerNo", txtCustNo.Text);
            //cmd.Parameters.Add("Name", txtName.Text);
            //cmd.Parameters.Add("FFTier", txtFFtier.Text);
            //cmd.Parameters.Add("IsCoop", chkCoop.Checked);
            //cmd.Parameters.Add("Price", txtPrice.Text);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nFFM_be_sqlDataSet1.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.nFFM_be_sqlDataSet1.tblCustomers);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customers_AddUpdate add = new Customers_AddUpdate();
            //this.Hide();
            add.ShowDialog();
            ////DBManager.ExecuteNonQuery("insertA");
            //String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            //SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand("Customers_Add", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("CustomerNo", txtCustNo.Text);
            //cmd.Parameters.Add("Name", txtName.Text);
            //cmd.Parameters.Add("FFTier", txtFFtier.Text);
            //cmd.Parameters.Add("IsCoop", chkCoop.Checked);
            //cmd.Parameters.Add("Price", txtPrice.Text);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //ResetFields();
            //LoadData();
        }

        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    ResetFields();
        //    LoadData();
        //}
        //private void ResetFields()
        //{
        //    txtCustNo.Text = "";
        //    txtName.Text = "";
        //    txtFFtier.Text = "";
        //    chkCoop.Checked = false;
        //    txtPrice.Text = "";
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectedRow = e.RowIndex;
            //DataGridViewRow row = dataGridView1.Rows[selectedRow];
            //txtCustNo.Text = row.Cells[1].Value.ToString();
            //txtName.Text = row.Cells[2].Value.ToString();
            //txtFFtier.Text = row.Cells[3].Value.ToString();
            //chkCoop.Checked = Convert.ToBoolean(row.Cells[4].Value);
            //txtPrice.Text = row.Cells[5].Value.ToString();
        }

        private void txtCustNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCustomerNo_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCustName_Click(object sender, EventArgs e)
        {

        }

        private void lblFFTier_Click(object sender, EventArgs e)
        {

        }

        private void txtFFtier_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCoOpMember_Click(object sender, EventArgs e)
        {

        }

        private void chkCoop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblCustomerPricing_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {

            if (DBManager.isDataLoaded == false)
            {
                LoadData();
            }
            // LoadData();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ShowUpdateInfoDialog();
            // DataGridViewRow row = dataGridView1.Rows[0];
            //txtCustNo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //txtName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //txtFFtier.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //chkCoop.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[4].Value);
            //txtPrice.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowUpdateInfoDialog();
        }
        private void ShowUpdateInfoDialog() {
            Customers_AddUpdate add = new Customers_AddUpdate();
            add.customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            add.txtCustNo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            add.txtName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            add.txtFFtier.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            add.chkCoop.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[3].Value);
            add.txtPrice.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            add.btnAdd.Text = "Update";
            add.lblAddUpdate.Text = "Update Customer Information";
            add.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row?", dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("Customers_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("CustomerId", customerId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DBManager.isDataLoaded = false;
                MessageBox.Show("Row is deleted successfully.");
            }
        }
    }
}
