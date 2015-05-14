using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Realm.Web.Startup))]
namespace Realm.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
