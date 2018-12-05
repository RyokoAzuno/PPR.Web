using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.DAL.Entities
{
    public class LastRepair
    {
        public int Id { get; set; }
        public string RepairType { get; set; }
        public string Technician { get; set; }
        public DateTime Date { get; set; }
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
