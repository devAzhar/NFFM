using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NFFM
{
    class DBManager
    {
        public static bool isDataLoaded = false;
        public static string NewTruckerId = string.Empty;

        public static DataTable GetDataTable(string SPName)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(SPName, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataSet GetDataSet(string SPName)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public static DataSet GetDataSet_New(string SPName, int receivingId)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.Add("receivingId", receivingId);
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
       public static DataSet GetDataSet_Report(string SPName, string receivedDate,string batchId,string invoiceNumber, string billOfLadingNumber, string customerName)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.Add("receivedDate", receivedDate);
            cmd.Parameters.Add("batchId", batchId);
            cmd.Parameters.Add("billOfLadingNumber", billOfLadingNumber);
            cmd.Parameters.Add("customerName", customerName);
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public static DataSet GetDataSet_FreightForwarding(string SPName, int shippingId)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.Add("shippingId", shippingId);
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public static int ExecuteNonQuery(string SPName) {
            int retValue = 0;
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(SPName, con);
            con.Open();
            retValue = cmd.ExecuteNonQuery();
            con.Close();
            return retValue;
        }
        public static int ExecuteNonQuery_New(string SPName, string receivingID, string lineItemID, string billOfLading,  string customerName, string shipper, string salesCode, string quantity, string receivedDate, string weekEndingDate, string truckerId, string batchId)
        {
            int retValue = 0;
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(SPName, con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("receivingId", receivingID);
                cmd.Parameters.Add("lineItemId", lineItemID);
                cmd.Parameters.Add("billOfLading", billOfLading);
                cmd.Parameters.Add("CustomerName", customerName);
                cmd.Parameters.Add("Shipper", shipper);
                cmd.Parameters.Add("SalesCode", salesCode);
                cmd.Parameters.Add("quantity", quantity);
                cmd.Parameters.Add("receivedDate", receivedDate);
                cmd.Parameters.Add("weekEndingDate", weekEndingDate);
                cmd.Parameters.Add("truckerId", truckerId);
                cmd.Parameters.Add("batchId", batchId); 
                con.Open();
                retValue = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex) {
                int code = ex.HResult;
                con.Close();
                retValue = 0;
            }
            return retValue;
        }
        public static int ExecuteNonQuery_FreightForwarding(string SPName, string shippingId, string lineItemID, string billOfLading, string customerName, string shipper, string salesCode, string quantity, string shippedDate, string weekEndingDate, string truckerId, string batchId)
        {
            int retValue = 0;
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(SPName, con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("shippingId", shippingId);
                cmd.Parameters.Add("lineItemId", lineItemID);
                cmd.Parameters.Add("billOfLading", billOfLading);
                cmd.Parameters.Add("CustomerName", customerName);
                cmd.Parameters.Add("Shipper", shipper);
                cmd.Parameters.Add("SalesCode", salesCode);
                cmd.Parameters.Add("quantity", quantity);
                cmd.Parameters.Add("ShippedDate", shippedDate);
                cmd.Parameters.Add("weekEndingDate", weekEndingDate);
                cmd.Parameters.Add("truckerId", truckerId);
                cmd.Parameters.Add("batchId", batchId);
                con.Open();
                retValue = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                int code = ex.HResult;
                con.Close();
                retValue = 0;
            }
            return retValue;
        }
    }
}
