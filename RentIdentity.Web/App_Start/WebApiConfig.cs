using System.Web.Http;

namespace RentIdentity.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.Routes.MapHttpRoute( //MapHTTPRoute for controllers inheriting ApiController
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
