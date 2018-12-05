using Ninject.Modules;
using PPR.BLL.Interfaces;
using PPR.BLL.Services;

namespace PPR.Web.Resolvers
{
    public class PPRModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBrigadeService>().To<BrigadeService>();
            Bind<IDepartmentService>().To<DepartmentService>();
            Bind<IEquipmentService>().To<EquipmentService>();
            Bind<ILastRepairService>().To<LastRepairService>();
            Bind<INextRepairService>().To<NextRepairService>();
        }
    }
}