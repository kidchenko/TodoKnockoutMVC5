using Microsoft.Owin;
using Owin;
using TodoKnockout;

[assembly: OwinStartup(typeof(Startup))]
namespace TodoKnockout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
