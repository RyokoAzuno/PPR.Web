using PPR.DAL.EFContext;
using PPR.DAL.Entities;
using PPR.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace PPR.DAL.Repositories
{
    public class EquipmentRepository : IRepository<Equipment>
    {
        private PPRContext _context;

        public EquipmentRepository(PPRContext context)
        {
            _context = context;
        }
        public void Create(Equipment item)
        {
            if (item != null)
                _context.Equipments.Add(item);
        }

        public void Delete(int id)
        {
            Equipment equipment = _context.Equipments.Where(e => e.Id == id).FirstOrDefault();
            if(equipment != null)
            {
                LastRepair lr = _context.LastRepairs.Where(l => l.EquipmentId == id).FirstOrDefault();
                NextRepair nr = _context.NextRepairs.Where(n => n.EquipmentId == id).FirstOrDefault();
                if (lr != null)
                    _context.LastRepairs.Remove(lr);
                if (nr != null)
                    _context.NextRepairs.Remove(nr);
                _context.Equipments.Remove(equipment);
            }
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments.Include(l => l.LastRepairs).Include(n => n.NextRepairs).ToList();
        }

        public Equipment GetById(int? id)
        {
            return _context.Equipments.Include(d => d.Department).Include(l => l.LastRepairs).Include(n => n.NextRepairs).Where(e => e.Id == id.Value).FirstOrDefault();
        }

        public void Update(Equipment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
