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
    public partial class Customers_AddUpdate : Form
    {
        public Customers_AddUpdate()
        {
            InitializeComponent();
            this.Text = "NFFM";
        }
        public int customerId = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Form1 main = new Form1();
            this.Hide();
            //main.ShowDialog();
            //main.LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Constants.Constants.ConnectionString))
            {
                using (var cmd = new SqlCommand("Customers_AddUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("CustomerId", customerId);
                    cmd.Parameters.Add("CustomerNo", txtCustNo.Text);
                    cmd.Parameters.Add("Name", txtName.Text);
                    cmd.Parameters.Add("FFTier", "0");
                    cmd.Parameters.Add("IsCoop", true);
                    cmd.Parameters.Add("Price", "0");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DBManager.isDataLoaded = false;
                    this.Hide();
                    //Form1 main = new Form1();
                    //ResetFields();
                    //main.LoadData();
                }
            }
        }

        private void txtFFtier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Globalization.CultureInfo c = System.Globalization.CultureInfo.CurrentUICulture;
            char dot = (char)c.NumberFormat.NumberDecimalSeparator[0];
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar.Equals(dot)))
                e.Handled = true;
        }
    }
}
