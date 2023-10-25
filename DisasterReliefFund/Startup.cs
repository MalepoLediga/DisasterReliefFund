using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DisasterReliefFund.Startup))]
namespace DisasterReliefFund
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
