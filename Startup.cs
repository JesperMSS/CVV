using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVSITEHT2021.Startup))]
namespace CVSITEHT2021
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
