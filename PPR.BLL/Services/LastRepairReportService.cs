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
    public class LastRepairReportService : IRepairReport<LastRepairReportInfoDTO>
    {
        private IUnitOfWork DB { get; set; }

        public LastRepairReportService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public LastRepairReportInfoDTO GetReport(int? equipmentId)
        {
            EquipmentDTO equipment = (new EquipmentService(DB)).GetEquipment(equipmentId.Value);
            LastRepairDTO lastRepair = (new LastRepairService(DB)).GetLastRepair(equipment.LastRepairs.Where(r => r.EquipmentId == equipmentId.Value).FirstOrDefault().Id) ?? null;
            LastRepairReportInfoDTO report = new LastRepairReportInfoDTO() {
                CurrentDate = DateTime.Now,
                Equipment = equipment,
                LastRepair = lastRepair,
                EquipmentId = equipmentId.Value,
                 LastRepairId = lastRepair.Id
            };
            return report;
        }
    }
}
