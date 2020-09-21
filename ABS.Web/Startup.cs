using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABSMVC.Startup))]
namespace ABSMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
