using Ninject.Modules;
using PPR.BLL.DataTransferObjects;
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
            Bind<IRepairReport<LastRepairReportInfoDTO>>().To<LastRepairReportService>();
            Bind<IRepairReport<NextRepairReportInfoDTO>>().To<NextRepairReportService>();
        }
    }
}