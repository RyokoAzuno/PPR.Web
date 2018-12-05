using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.DataTransferObjects
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int NumberOfEngines { get; set; }
        public int Power { get; set; }
        public float URC { get; set; }
        public string Notes { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
        public ICollection<LastRepairDTO> LastRepairs { get; set; }
        public ICollection<NextRepairDTO> NextRepairs { get; set; }

        public EquipmentDTO()
        {
            LastRepairs = new List<LastRepairDTO>();
            NextRepairs = new List<NextRepairDTO>();
        }
    }
}
