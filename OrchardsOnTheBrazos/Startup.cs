using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrchardsOnTheBrazos.Startup))]
namespace OrchardsOnTheBrazos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
