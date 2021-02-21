namespace NFFM.Web
{
    using NFFM.Utility;
    using System.Configuration;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public static class ApplicationConfig
    {
        public static string ConnectionString
        {
            get;
            private set;
        }
        private static void Start(HttpApplication app)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void Init(HttpApplication app)
        {
            Start(app);
            Database.ConnectionString = ApplicationConfig.ConnectionString = ConfigurationManager.ConnectionStrings["NFFM"]?.ConnectionString;
        }
    }
}