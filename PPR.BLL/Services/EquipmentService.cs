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
    public class EquipmentService : IEquipmentService
    {
        private IUnitOfWork DB { get; set; }

        public EquipmentService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }

        public void CreateEquipment(EquipmentDTO equip)
        {
            throw new NotImplementedException();
        }

        public void DeleteEquipment(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentDTO> GetAllEquipments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Equipment, EquipmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Equipment>, List<EquipmentDTO>>(DB.Equipments.GetAll());
        }

        public EquipmentDTO GetEquipment(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Equipment, EquipmentDTO>()).CreateMapper();
            return mapper.Map<Equipment, EquipmentDTO>(DB.Equipments.GetById(id.Value));
        }

        public void UpdateEquipment(EquipmentDTO equip)
        {
            throw new NotImplementedException();
        }
    }
}
