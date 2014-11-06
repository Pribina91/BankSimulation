using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankSimulation.Startup))]
namespace BankSimulation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
