using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using RentIdentity.Data.Entities;

namespace RentIdentity.Web
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {   
            //This has to be called before the following OData mapping, so also before WebApi mapping
            config.MapHttpAttributeRoutes(); 
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<RentalUnit>("RentalUnits");
            config.Routes.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());
        }
    }
}