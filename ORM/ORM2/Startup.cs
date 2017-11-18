using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ORM2.Startup))]
namespace ORM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
