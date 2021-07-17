namespace NFFM.Constants
{
    public static class Constants
    {
        public static string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["NFFM"].ConnectionString;
    }
}
