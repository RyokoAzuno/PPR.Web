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
    public class NextRepairService : INextRepairService
    {
        private IUnitOfWork DB { get; set; }

        public NextRepairService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public void CreateNextRepair(NextRepairDTO nxtRepair)
        {
            NextRepair nr = MyMapper<NextRepairDTO, NextRepair>.Map(nxtRepair);
            DB.NextRepairs.Create(nr);
            DB.Commit();
        }

        public void DeleteNextRepair(int id)
        {
            DB.NextRepairs.Delete(id);
            DB.Commit();
        }

        public IEnumerable<NextRepairDTO> GetAllNextRepairs()
        {
            return MyMapper<NextRepair, NextRepairDTO>.Map(DB.NextRepairs.GetAll());
        }

        public NextRepairDTO GetNextRepair(int? id)
        {
            return MyMapper<NextRepair, NextRepairDTO>.Map(DB.NextRepairs.GetById(id.Value));
        }

        public void UpdateNextRepair(NextRepairDTO nxtRepair)
        {
            NextRepair nr = MyMapper<NextRepairDTO, NextRepair>.Map(nxtRepair);
            DB.NextRepairs.Update(nr);
            DB.Commit();
        }

        public dynamic GetEquipmentsIdsAndNames()
        {
            return DB.Equipments.GetAll().Select(e => new { e.Id, e.Name });
        }

        public IEnumerable<string> GetRepairTypes()
        {
            return DB.NextRepairs.GetAll().Select(rt => rt.RepairType).Distinct();
        }

        public IEnumerable<string> GetTechniciansNames()
        {
            return DB.Brigades.GetAll().Select(b => b.BrigadeChiefName).Distinct();
        }

        public IEnumerable<string> GetTechniciansNamesByDepartments(int? departmentCode)
        {
            return DB.Brigades.GetAll().Where(b => b.Department.Code == departmentCode).Select(b => b.BrigadeChiefName).Distinct();
        }
    }
}
