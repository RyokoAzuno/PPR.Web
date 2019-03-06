using Ninject.Modules;
using PPR.CrossCutting.Interfaces;
using PPR.CrossCutting.Services;

namespace PPR.Web.Resolvers
{
    public class PPRIdentityModule : NinjectModule
    {
        private string _connectionString;

        public PPRIdentityModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IIdentityUserService>().To<IdentityUserService>().WithConstructorArgument(_connectionString);
        }
    }
}