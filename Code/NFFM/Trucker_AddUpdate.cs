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
    public partial class Trucker_AddUpdate : Form
    {
        public Trucker_AddUpdate()
        {
            DBManager.NewTruckerId = string.Empty;

            InitializeComponent();
            this.Text = "NFFM";
        }
        public int TruckerID = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Form1 main = new Form1();
            this.Hide();
            //main.ShowDialog();
            //main.LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            //SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand("Truckers_AddUpdate", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("TruckerID", TruckerID);
            //cmd.Parameters.Add("Trucker", txtTrucker.Text);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            var sql = string.Format("exec Truckers_AddUpdate @TruckerID={0}, @Trucker='{1}'", TruckerID, txtTrucker.Text.Replace("'", "''"));

            using (DataTable dt = DBManager.GetDataTable(sql))
            {
                if(TruckerID == 0)
                {
                    DBManager.NewTruckerId = dt.Rows[0]["TruckerID"].ToString();
                    if (DBManager.currentRecordId == -1)
                    {
                        int retVal = DBManager.ExecuteNonQuery_New("BillOfLading_AddUpdate", "0", "", "", "", "", "", "", "", "", DBManager.NewTruckerId, "");
                    }
                }
            }

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
