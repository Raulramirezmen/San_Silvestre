using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(San_Silvestre.Startup))]
namespace San_Silvestre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
