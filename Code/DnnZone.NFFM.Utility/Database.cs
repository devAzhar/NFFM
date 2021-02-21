namespace NFFM.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public static class Database
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection Connection => new SqlConnection(ConnectionString);

        public static int Execute(string query)
        {
            using (var connection = Connection)
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static DataSet GetDataSet(string query)
        {
            using (var connection = Connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                var adapt = new SqlDataAdapter(command);
                connection.Open();
                var dataSet = new DataSet();
                adapt.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
        }

        public static DataTable GetDataTable(string query)
        {
            using (var connection = Connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                var adapt = new SqlDataAdapter(command);
                connection.Open();
                var table = new DataTable();
                adapt.Fill(table);
                connection.Close();

                return table;
            }
        }
    }
}
