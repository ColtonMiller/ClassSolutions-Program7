using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstContactForm.Startup))]
namespace MyFirstContactForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
