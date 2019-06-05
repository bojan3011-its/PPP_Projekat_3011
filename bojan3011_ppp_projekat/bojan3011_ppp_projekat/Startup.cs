using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bojan3011_ppp_projekat.Startup))]
namespace bojan3011_ppp_projekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
