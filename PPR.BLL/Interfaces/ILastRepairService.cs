using PPR.BLL.DataTransferObjects;
using System.Collections.Generic;

namespace PPR.BLL.Interfaces
{
    public interface ILastRepairService
    {
        IEnumerable<LastRepairDTO> GetAllLastRepairs();
        LastRepairDTO GetLastRepair(int? id);
        void CreateLastRepair(LastRepairDTO lstRepair);
        void UpdateLastRepair(LastRepairDTO lstRepair);
        void DeleteLastRepair(int id);
        dynamic GetEquipmentsIdsAndNames();
        IEnumerable<string> GetRepairTypes();
        IEnumerable<string> GetTechniciansNames();
    }
}
