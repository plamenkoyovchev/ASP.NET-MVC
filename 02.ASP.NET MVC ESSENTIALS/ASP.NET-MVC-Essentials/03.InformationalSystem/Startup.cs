using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03.InformationalSystem.Startup))]
namespace _03.InformationalSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
