namespace NFFM
{
    using System;
    using System.Data;
    using System.IO;
    using System.Text;

    public static class DataTableExtensions
    {
        public static void WriteToCsvFile(this DataTable dataTable, string filePath)
        {
            var fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    var columnType = column.GetType().Name;

                    if (columnType == "DateTime" || columnType == "Date")
                    {
                        fileContent.Append("\"" + DateTime.Parse(column.ToString()).ToString("d") + "\",");
                    }
                    else
                    {
                        fileContent.Append("\"" + column.ToString() + "\",");
                    }
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            File.WriteAllText(filePath, fileContent.ToString());
        }
    }
}