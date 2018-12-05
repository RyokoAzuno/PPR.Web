using System.Collections.Generic;

namespace PPR.BLL.DataTransferObjects
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int NumberOfBrigades { get; set; }
        public ICollection<BrigadeDTO> Brigades { get; set; }
        public ICollection<EquipmentDTO> Equipments { get; set; }

        public DepartmentDTO()
        {
            Equipments = new List<EquipmentDTO>();
            Brigades = new List<BrigadeDTO>();
        }
    }
}
