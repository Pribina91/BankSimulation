using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankSimulating.Startup))]
namespace BankSimulating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
