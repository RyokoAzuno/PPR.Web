using PPR.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentDTO> GetAllEquipments();
        EquipmentDTO GetEquipment(int? id);
        void CreateEquipment(EquipmentDTO equip);
        void UpdateEquipment(EquipmentDTO equip);
        void DeleteEquipment(int id);
    }
}
