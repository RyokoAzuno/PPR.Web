using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.DAL.Entities
{
    public class Equipment
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
        public Department Department { get; set; }

        public ICollection<LastRepair> LastRepairs { get; set; }
        public ICollection<NextRepair> NextRepairs { get; set; }

        public Equipment()
        {
            LastRepairs = new List<LastRepair>();
            NextRepairs = new List<NextRepair>();
        }

    }
}
