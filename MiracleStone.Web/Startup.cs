using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiracleStone.Web.Startup))]
namespace MiracleStone.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
