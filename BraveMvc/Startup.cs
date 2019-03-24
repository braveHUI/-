using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BraveMvc.Startup))]
namespace BraveMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
            //这个是下一篇永久连接类的 我们先不用
            //app.MapSignalR<MyConnection>("/echo");
        }
    }
}
