using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RentIdentity.Data;
using RentIdentity.Web;

namespace RentIdentity.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            {
                //Database.SetInitializer(new DropCreateDatabaseAlways<RentIdentityDb>());
                GlobalConfiguration.Configuration.Formatters.Clear();
                GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(config =>
                {
                    ODataConfig.Register(config); //this has to be before WebApi
                    GlobalConfiguration.Configure(WebApiConfig.Register);


                });
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

            }

        }


    }
}
