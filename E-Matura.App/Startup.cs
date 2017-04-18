using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Matura.App.Startup))]
namespace E_Matura.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
	        this.ConfigureAuth(app);
        }
    }
}
