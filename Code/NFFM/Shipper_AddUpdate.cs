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
    public partial class Shipper_AddUpdate : Form
    {
        public Shipper_AddUpdate()
        {
            InitializeComponent();
            this.Text = "NFFM";
        }
        public int ShipperID = 0; 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Form1 main = new Form1();
            this.Hide();
            //main.ShowDialog();
            //main.LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("Shippers_AddUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ShipperID", ShipperID);
            cmd.Parameters.Add("Shipper", txtShipper.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DBManager.isDataLoaded = false;
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
