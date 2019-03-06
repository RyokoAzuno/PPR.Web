using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Ninject.Modules;
using Owin;
using PPR.CrossCutting.Interfaces;
using PPR.CrossCutting.Services;
using PPR.Web.Resolvers;

[assembly: OwinStartup(typeof(PPR.Web.App_Start.Startup))]
namespace PPR.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => { return CreateUserService(); });
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
        private IIdentityUserService CreateUserService()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IIdentityUserService>().To<IdentityUserService>().WithConstructorArgument("IdentityConnection");
            return kernel.Get<IIdentityUserService>();
        }
    }
}