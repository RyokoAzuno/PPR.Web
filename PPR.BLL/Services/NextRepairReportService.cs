using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
using PPR.CrossCutting.Utils;
using PPR.DAL.Entities;
using PPR.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Services
{
    public class NextRepairReportService : IRepairReport<NextRepairReportInfoDTO>
    {
        private IUnitOfWork DB { get; set; }

        public NextRepairReportService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public NextRepairReportInfoDTO GetReport(int? equipmentId)
        {
            EquipmentDTO equipment = (new EquipmentService(DB)).GetEquipment(equipmentId.Value);
            NextRepairDTO nextRepair = (new NextRepairService(DB)).GetNextRepair(equipment.NextRepairs.Where(r => r.EquipmentId == equipmentId.Value).FirstOrDefault().Id) ?? null;
            NextRepairReportInfoDTO report = new NextRepairReportInfoDTO() {
                CurrentDate = DateTime.Now,
                Equipment = equipment,
                NextRepair = nextRepair,
                EquipmentId = equipmentId.Value,
                NextRepairId = nextRepair.Id
            };
            return report;
        }
    }
}
