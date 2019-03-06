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
    public class LastRepairService : ILastRepairService
    {
        private IUnitOfWork DB { get; set; }

        public LastRepairService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public void CreateLastRepair(LastRepairDTO lstRepair)
        {
            LastRepair lr = MyMapper<LastRepairDTO, LastRepair>.Map(lstRepair);
            DB.LastRepairs.Create(lr);
            DB.Commit();
        }

        public void DeleteLastRepair(int id)
        {
            DB.LastRepairs.Delete(id);
            DB.Commit();
        }

        public IEnumerable<LastRepairDTO> GetAllLastRepairs()
        {
            return MyMapper<LastRepair, LastRepairDTO>.Map(DB.LastRepairs.GetAll());
        }

        public LastRepairDTO GetLastRepair(int? id)
        {
            return MyMapper<LastRepair, LastRepairDTO>.Map(DB.LastRepairs.GetById(id.Value));
        }

        public void UpdateLastRepair(LastRepairDTO lstRepair)
        {
            LastRepair lr = MyMapper<LastRepairDTO, LastRepair>.Map(lstRepair);
            DB.LastRepairs.Update(lr);
            DB.Commit();
        }

        public dynamic GetEquipmentsIdsAndNames()
        {
            return DB.Equipments.GetAll().Select(e => new { e.Id, e.Name });
        }

        public IEnumerable<string> GetRepairTypes()
        {
            return DB.LastRepairs.GetAll().Select(rt => rt.RepairType).Distinct();
        }

        public IEnumerable<string> GetTechniciansNames()
        {
            return DB.LastRepairs.GetAll().Select(rt => rt.Technician).Distinct();
        }
    }
}
