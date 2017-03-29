using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Planificador.Startup))]
namespace Planificador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
