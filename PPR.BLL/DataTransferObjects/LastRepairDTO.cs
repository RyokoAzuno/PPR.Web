using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.DataTransferObjects
{
    public class LastRepairDTO
    {
        public int Id { get; set; }
        public string RepairType { get; set; }
        public string Technician { get; set; }
        public DateTime Date { get; set; }
        public int? EquipmentId { get; set; }
        public EquipmentDTO Equipment { get; set; }
    }
}
