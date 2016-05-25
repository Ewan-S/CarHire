using CarHire;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CarHire
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}