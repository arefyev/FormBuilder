using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormBuilder.Web.Startup))]
namespace FormBuilder.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
