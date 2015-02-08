using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenAuthPrototype.Startup))]
namespace OpenAuthPrototype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
