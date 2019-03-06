using PPR.BLL.DataTransferObjects;
using System.Collections.Generic;

namespace PPR.BLL.Interfaces
{
    public interface INextRepairService
    {
        IEnumerable<NextRepairDTO> GetAllNextRepairs();
        NextRepairDTO GetNextRepair(int? id);
        void CreateNextRepair(NextRepairDTO nxtRepair);
        void UpdateNextRepair(NextRepairDTO nxtRepair);
        void DeleteNextRepair(int id);
        dynamic GetEquipmentsIdsAndNames();
        IEnumerable<string> GetRepairTypes();
        IEnumerable<string> GetTechniciansNames();
        IEnumerable<string> GetTechniciansNamesByDepartments(int? departmentCode);
    }
}
