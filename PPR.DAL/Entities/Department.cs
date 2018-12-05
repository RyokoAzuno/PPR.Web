using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int NumberOfBrigades { get; set; }
        public ICollection<Brigade> Brigades { get; set; }
        public ICollection<Equipment> Equipments { get; set; }

        public Department()
        {
            Equipments = new List<Equipment>();
            Brigades = new List<Brigade>();
        }
    }
}
