using PPR.BLL.DataTransferObjects;
using System.Collections.Generic;

namespace PPR.BLL.Interfaces
{
    public interface IBrigadeService
    {
        IEnumerable<BrigadeDTO> GetAllBrigades();
        BrigadeDTO GetBrigade(int? id);
        void CreateBrigade(BrigadeDTO brigade);
        void UpdateBrigade(BrigadeDTO brigade);
        void DeleteBrigade(int id);
        dynamic GetDepartmentsNamesAndCodes();
    }
}
