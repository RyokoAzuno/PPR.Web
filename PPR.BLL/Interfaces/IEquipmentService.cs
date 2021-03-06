﻿using PPR.BLL.DataTransferObjects;
using System.Collections.Generic;

namespace PPR.BLL.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentDTO> GetAllEquipments();
        EquipmentDTO GetEquipment(int? id);
        void CreateEquipment(EquipmentDTO equip);
        void UpdateEquipment(EquipmentDTO equip);
        void DeleteEquipment(int id);
        dynamic GetDepartmentsNamesAndCodes();
    }
}
