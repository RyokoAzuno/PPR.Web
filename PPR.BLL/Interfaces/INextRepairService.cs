using PPR.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Interfaces
{
    public interface INextRepairService
    {
        IEnumerable<NextRepairDTO> GetAllNextRepairs();
        NextRepairDTO GetNextRepair(int? id);
        void CreateNextRepair(NextRepairDTO nxtRepair);
        void UpdateNextRepair(NextRepairDTO nxtRepair);
        void DeleteNextRepair(int id);
    }
}
