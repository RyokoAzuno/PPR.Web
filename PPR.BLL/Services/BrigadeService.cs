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
    public class BrigadeService : IBrigadeService
    {
        private IUnitOfWork DB { get; set; }

        public BrigadeService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }

        public void CreateBrigade(BrigadeDTO brigade)
        {
            Brigade newBrigade = MyMapper<BrigadeDTO, Brigade>.Map(brigade);
            DB.Brigades.Create(newBrigade);
            DB.Commit();
        }

        public void DeleteBrigade(int id)
        {
            DB.Brigades.Delete(id);
            DB.Commit();
        }

        public IEnumerable<BrigadeDTO> GetAllBrigades()
        {
            return MyMapper<Brigade, BrigadeDTO>.Map(DB.Brigades.GetAll());
        }

        public BrigadeDTO GetBrigade(int? id)
        {
            return MyMapper<Brigade, BrigadeDTO>.Map(DB.Brigades.GetById(id.Value));
        }

        public void UpdateBrigade(BrigadeDTO brigade)
        {
            Brigade b = MyMapper<BrigadeDTO, Brigade>.Map(brigade);
            DB.Brigades.Update(b);
            DB.Commit();
        }

        public dynamic GetDepartmentsNamesAndCodes()
        {
            return DB.Departments.GetAll().Select(n => new { n.Code, n.Name });
        }
    }
}
