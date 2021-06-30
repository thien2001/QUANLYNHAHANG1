using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QUANLYNHAHANG.Startup))]
namespace QUANLYNHAHANG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
