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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments.Include(l => l.LastRepairs).Include(n => n.NextRepairs).ToList();
        }

        public Equipment GetById(int? id)
        {
            return _context.Equipments.Where(e => e.Id == id.Value).FirstOrDefault();
        }

        public void Update(Equipment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
