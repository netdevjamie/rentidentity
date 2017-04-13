using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentIdentity.Web.Startup))]
namespace RentIdentity.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
