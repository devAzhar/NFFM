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
    public partial class SalesCode : Form
    {
        public SalesCode()
        {
            InitializeComponent();
            this.Text = "NFFM";
            DBManager.isDataLoaded = false;
        }
        int selectedRow;
        
        public void LoadData()
        {
            String SPName = "SalesCode_GetAll";
            DataTable dt = DBManager.GetDataTable(SPName);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["SalesCodeID"].Visible = false;
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
            dataGridView1.Columns["Sales Code"].Width = 115;
            dataGridView1.Columns["Description"].Width = 180; 
            dataGridView1.Columns["Unit of Measure"].Width = 180;
            dataGridView1.Columns["Price"].Width = 73;
            dataGridView1.Columns["FF Tier 1"].Width = 95;
            dataGridView1.Columns["FF Tier 2"].Width = 95;
            dataGridView1.Columns["FF Tier 3"].Width = 95;
            DBManager.isDataLoaded = true;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nFFM_be_sqlDataSet1.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.nFFM_be_sqlDataSet1.tblCustomers);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SalesCode_AddUpdate add = new SalesCode_AddUpdate();
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
            SalesCode_AddUpdate add = new SalesCode_AddUpdate();
            add.SalesCodeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            add.txtSalesCode.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            add.txtDescription.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            add.txtUOM.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            add.txtPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            add.txtFFTier1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            add.txtFFTier2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            add.txtFFTier3.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            add.btnAdd.Text = "Update";
            add.lblAddUpdate.Text = "Update Sales Codes Information";
            add.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row?", dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int SalesCodeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("SalesCode_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("SalesCodeID", SalesCodeID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DBManager.isDataLoaded = false;
                MessageBox.Show("Row is deleted successfully.");
            }
        }
    }
}
