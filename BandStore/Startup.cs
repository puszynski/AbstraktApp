using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BandStore.Startup))]
namespace BandStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
