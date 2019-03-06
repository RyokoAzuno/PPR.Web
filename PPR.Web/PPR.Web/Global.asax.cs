using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PPR.BLL.Dependencies;
using PPR.Web.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PPR.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Ninject modules
            NinjectModule orderModule = new PPRModule();
            NinjectModule serviceModule = new ServiceModule("MyDbConnection");
            //NinjectModule pprIdentityModule = new PPRIdentityModule("IdentityConnection");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
