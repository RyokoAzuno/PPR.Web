using AutoMapper;
using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeDTO, Brigade>()).CreateMapper();
            Brigade b = mapper.Map<BrigadeDTO, Brigade>(brigade);
            DB.Brigades.Create(b);
            DB.Commit();
        }

        public void DeleteBrigade(int id)
        {
            DB.Brigades.Delete(id);
            DB.Commit();
        }

        public IEnumerable<BrigadeDTO> GetAllBrigades()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brigade, BrigadeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Brigade>, List<BrigadeDTO>>(DB.Brigades.GetAll());
        }

        public BrigadeDTO GetBrigade(int? id)
        {
            //var brigade = DB.Brigades.GetById(id.Value);
            //return new BrigadeDTO
            //{
            //    Id = brigade.Id, 
            //    Code = brigade.Department.Code,
            //    BrigadeChiefName = brigade.BrigadeChiefName,
            //    NumberOfPeople = brigade.NumberOfPeople,
            //    DepartmentId = brigade.DepartmentId
            //};
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brigade, BrigadeDTO>()).CreateMapper();
            return mapper.Map<Brigade, BrigadeDTO>(DB.Brigades.GetById(id.Value));
        }

        public void UpdateBrigade(BrigadeDTO brigade)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeDTO, Brigade>()).CreateMapper();
            Brigade b = mapper.Map<BrigadeDTO, Brigade>(brigade);
            DB.Brigades.Update(b);
            DB.Commit();
        }
    }
}
