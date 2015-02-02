using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MailExp.Startup))]
namespace MailExp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
