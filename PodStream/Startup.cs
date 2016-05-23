using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PodStream.Startup))]
namespace PodStream
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
