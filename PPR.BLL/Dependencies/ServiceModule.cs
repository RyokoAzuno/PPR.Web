using Ninject.Modules;
using PPR.DAL.Interfaces;
using PPR.DAL.Repositories;

namespace PPR.BLL.Dependencies
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<PPRUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
