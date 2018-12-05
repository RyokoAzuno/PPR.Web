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
    public class LastRepairService : ILastRepairService
    {
        private IUnitOfWork DB { get; set; }

        public LastRepairService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public void CreateLastRepair(LastRepairDTO lstRepair)
        {
            throw new NotImplementedException();
        }

        public void DeleteLastRepair(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LastRepairDTO> GetAllLastRepairs()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LastRepair, LastRepairDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<LastRepair>, List<LastRepairDTO>>(DB.LastRepairs.GetAll());
        }

        public LastRepairDTO GetLastRepair(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LastRepair, LastRepairDTO>()).CreateMapper();
            return mapper.Map<LastRepair, LastRepairDTO>(DB.LastRepairs.GetById(id.Value));
        }

        public void UpdateLastRepair(LastRepairDTO lstRepair)
        {
            throw new NotImplementedException();
        }
    }
}
