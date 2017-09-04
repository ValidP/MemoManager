using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemoManager.Startup))]
namespace MemoManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
