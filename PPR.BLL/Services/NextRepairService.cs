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
    public class NextRepairService : INextRepairService
    {
        private IUnitOfWork DB { get; set; }

        public NextRepairService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public void CreateNextRepair(NextRepairDTO nxtRepair)
        {
            throw new NotImplementedException();
        }

        public void DeleteNextRepair(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NextRepairDTO> GetAllNextRepairs()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NextRepair, NextRepairDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<NextRepair>, List<NextRepairDTO>>(DB.NextRepairs.GetAll());
        }

        public NextRepairDTO GetNextRepair(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NextRepair, NextRepairDTO>()).CreateMapper();
            return mapper.Map<NextRepair, NextRepairDTO>(DB.NextRepairs.GetById(id.Value));

        }

        public void UpdateNextRepair(NextRepairDTO nxtRepair)
        {
            throw new NotImplementedException();
        }
    }
}
