using PPR.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Interfaces
{
    public interface ILastRepairService
    {
        IEnumerable<LastRepairDTO> GetAllLastRepairs();
        LastRepairDTO GetLastRepair(int? id);
        void CreateLastRepair(LastRepairDTO lstRepair);
        void UpdateLastRepair(LastRepairDTO lstRepair);
        void DeleteLastRepair(int id);
    }
}
