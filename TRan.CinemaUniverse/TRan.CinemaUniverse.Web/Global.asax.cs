using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using TRan.CinemaUniverse.Data;
using TRan.CinemaUniverse.Data.Migrations;
using TRan.CinemaUniverse.Web.App_Start;

namespace TRan.CinemaUniverse.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CinemaSqlDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var mapper = new AutoMapperConfig();
            mapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
