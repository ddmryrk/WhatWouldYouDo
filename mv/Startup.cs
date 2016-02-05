using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mv.Startup))]
namespace mv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
