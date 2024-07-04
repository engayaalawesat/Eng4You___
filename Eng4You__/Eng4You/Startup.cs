using Google.Cloud.Translation.V2;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
