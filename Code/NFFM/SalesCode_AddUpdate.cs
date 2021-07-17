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
    public partial class SalesCode_AddUpdate : Form
    {
        public SalesCode_AddUpdate()
        {
            InitializeComponent();
            this.Text = "NFFM";
        }
        public int SalesCodeID = 0; 
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
                using (SqlCommand cmd = new SqlCommand("SalesCode_AddUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("SalesCodeID", SalesCodeID);
                    cmd.Parameters.Add("SalesCode", txtSalesCode.Text);
                    cmd.Parameters.Add("Description", txtDescription.Text);
                    cmd.Parameters.Add("UnityOfMeasure", txtUOM.Text);
                    cmd.Parameters.Add("Price", txtPrice.Text);
                    cmd.Parameters.Add("FFTier1", "0");
                    cmd.Parameters.Add("FFTier2", "0");
                    cmd.Parameters.Add("FFTier3", "0");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DBManager.isDataLoaded = false;
                }
            }
            this.Hide();
        }

        private void txtFFtier_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Globalization.CultureInfo c = System.Globalization.CultureInfo.CurrentUICulture;
            char dot = (char)c.NumberFormat.NumberDecimalSeparator[0];
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar.Equals(dot)))
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
