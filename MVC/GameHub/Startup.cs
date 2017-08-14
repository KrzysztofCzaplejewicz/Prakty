using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GameHub.Startup))]

namespace GameHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
         //   app.map<PerfHub>("/echo");

            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
