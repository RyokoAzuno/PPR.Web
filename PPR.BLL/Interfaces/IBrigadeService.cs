using PPR.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Interfaces
{
    public interface IBrigadeService
    {
        IEnumerable<BrigadeDTO> GetAllBrigades();
        BrigadeDTO GetBrigade(int? id);
        void CreateBrigade(BrigadeDTO brigade);
        void UpdateBrigade(BrigadeDTO brigade);
        void DeleteBrigade(int id);
    }
}
