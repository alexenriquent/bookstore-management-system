using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreManagementSystem.Startup))]
namespace BookStoreManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
