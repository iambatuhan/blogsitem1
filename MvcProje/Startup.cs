using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(MvcProje.Startup))]

namespace MvcProje
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // SignalR'ı başlat
            app.MapSignalR();
        }
    }
}
