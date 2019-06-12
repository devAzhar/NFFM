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
    public partial class Shipper : Form
    {
        public Shipper()
        {
            InitializeComponent();
            this.Text = "Shippers";
            DBManager.isDataLoaded = false;
        }
        int selectedRow;
        
        public void LoadData()
        {
            String SPName = "Shippers_GetAll";
            DataTable dt = DBManager.GetDataTable(SPName);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ShipperID"].Visible = false;
            dataGridView1.Columns[1].Width = 303;
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
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nFFM_be_sqlDataSet1.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.nFFM_be_sqlDataSet1.tblCustomers);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Shipper_AddUpdate add = new Shipper_AddUpdate();
            //this.Hide();
            add.ShowDialog();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowUpdateInfoDialog();
        }
        private void ShowUpdateInfoDialog() {
            Shipper_AddUpdate add = new Shipper_AddUpdate();
            add.ShipperID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            add.txtShipper.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            add.btnAdd.Text = "Update";
            add.lblAddUpdate.Text = "Update Shipper Information";
            add.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row?", dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ShipperID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("Shippers_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ShipperID", ShipperID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DBManager.isDataLoaded = false;
                MessageBox.Show("Row is deleted successfully.");
            }
        }
    }
}
