﻿using System;
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
        public static int currentRecordId = 0;
        public static DataTable GetDataTable(string SPName)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;

            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(SPName, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();
                        return dt;
                    }
                }
            }
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
            cmd.Parameters.AddWithValue("receivingId", receivingId);
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
       public static DataSet GetDataSet_Report(string SPName, string receivedDate,string batchId,string invoiceNumber, string billOfLadingNumber, string customerName, bool ExportToExcel)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("receivedDate", receivedDate);
            cmd.Parameters.AddWithValue("batchId", batchId);
            cmd.Parameters.AddWithValue("billOfLadingNumber", billOfLadingNumber);
            cmd.Parameters.AddWithValue("customerName", customerName);
            cmd.Parameters.AddWithValue("ExportToExcel", ExportToExcel); 
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
            cmd.Parameters.AddWithValue("shippingId", shippingId);
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public static DataSet GetDataSet_FreightForwardingReport(string SPName, string shippedDate, string batchId, string invoiceNumber, string billOfLadingNumber, string customerName)
        {
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("shippedDate", shippedDate);
            cmd.Parameters.AddWithValue("batchId", batchId);
            cmd.Parameters.AddWithValue("billOfLadingNumber", billOfLadingNumber);
            cmd.Parameters.AddWithValue("customerName", customerName);
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
            var str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;


            using (SqlConnection con = new SqlConnection(str))
            {

                using (SqlCommand cmd = new SqlCommand(SPName, con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("receivingId", receivingID);
                        cmd.Parameters.AddWithValue("lineItemId", lineItemID);
                        cmd.Parameters.AddWithValue("billOfLading", billOfLading);
                        cmd.Parameters.AddWithValue("CustomerName", customerName);
                        cmd.Parameters.AddWithValue("Shipper", shipper);
                        cmd.Parameters.AddWithValue("SalesCode", salesCode);
                        cmd.Parameters.AddWithValue("quantity", quantity);
                        cmd.Parameters.AddWithValue("receivedDate", receivedDate);
                        cmd.Parameters.AddWithValue("weekEndingDate", weekEndingDate);
                        cmd.Parameters.AddWithValue("truckerId", truckerId);
                        cmd.Parameters.AddWithValue("batchId", batchId);
                        con.Open();
                        //retValue = cmd.ExecuteNonQuery();
                        retValue = 0;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                int.TryParse(dt.Rows[0][0].ToString(), out retValue);
                            }
                            //con.Close();
                            //return dt;
                        }

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
        public static int ExecuteNonQuery_FreightForwarding(string SPName, string shippingId, string lineItemID, string billOfLading, string customerName, string shipper, string salesCode, string quantity, string shippedDate, string weekEndingDate, string truckerId, string batchId)
        {
            int retValue = 0;
            String str = System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {

                using (SqlCommand cmd = new SqlCommand(SPName, con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("shippingId", shippingId);
                        cmd.Parameters.AddWithValue("lineItemId", lineItemID);
                        cmd.Parameters.AddWithValue("billOfLading", billOfLading);
                        cmd.Parameters.AddWithValue("CustomerName", customerName);
                        cmd.Parameters.AddWithValue("Shipper", shipper);
                        cmd.Parameters.AddWithValue("SalesCode", salesCode);
                        cmd.Parameters.AddWithValue("quantity", quantity);
                        cmd.Parameters.AddWithValue("ShippedDate", shippedDate);
                        cmd.Parameters.AddWithValue("weekEndingDate", weekEndingDate);
                        cmd.Parameters.AddWithValue("truckerId", truckerId);
                        cmd.Parameters.AddWithValue("batchId", batchId);
                        con.Open();
                        //retValue = cmd.ExecuteNonQuery();
                        retValue = 0;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                int.TryParse(dt.Rows[0][0].ToString(), out retValue);
                            }
                            //con.Close();
                            //return dt;
                        }

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
    }
}
