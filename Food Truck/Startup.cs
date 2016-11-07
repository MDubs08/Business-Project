using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Food_Truck.Startup))]
namespace Food_Truck
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
