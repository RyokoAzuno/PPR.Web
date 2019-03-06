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
    public class EquipmentService : IEquipmentService
    {
        private IUnitOfWork DB { get; set; }

        public EquipmentService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }

        public void CreateEquipment(EquipmentDTO equip)
        {
            Equipment e = MyMapper<EquipmentDTO, Equipment>.Map(equip);
            DB.Equipments.Create(e);
            DB.Commit();
        }

        public void DeleteEquipment(int id)
        {
            DB.Equipments.Delete(id);
            DB.Commit();
        }

        public IEnumerable<EquipmentDTO> GetAllEquipments()
        {
            return MyMapper<Equipment, EquipmentDTO>.Map(DB.Equipments.GetAll());
        }

        public EquipmentDTO GetEquipment(int? id)
        {
            return MyMapper<Equipment, EquipmentDTO>.Map(DB.Equipments.GetById(id.Value));
        }

        public void UpdateEquipment(EquipmentDTO equip)
        {
            Equipment e = MyMapper<EquipmentDTO, Equipment>.Map(equip);
            DB.Equipments.Update(e);
            DB.Commit();
        }

        public dynamic GetDepartmentsNamesAndCodes()
        {
            return DB.Departments.GetAll().Select(n => new { n.Id, n.Name });
        }
    }
}
