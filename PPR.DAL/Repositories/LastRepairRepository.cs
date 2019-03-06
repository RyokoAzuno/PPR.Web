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
    public class LastRepairRepository : IRepository<LastRepair>
    {
        private PPRContext _context;

        public LastRepairRepository(PPRContext context)
        {
            _context = context;
        }
        public void Create(LastRepair item)
        {
            if (item != null)
                _context.LastRepairs.Add(item);
        }

        public void Delete(int id)
        {
            LastRepair lr = _context.LastRepairs.Where(l => l.Id == id).FirstOrDefault();
            if (lr != null)
                _context.LastRepairs.Remove(lr);
        }

        public IEnumerable<LastRepair> GetAll() => _context.LastRepairs.Include(l => l.Equipment).ToList();

        public LastRepair GetById(int? id) => _context.LastRepairs.Include(l => l.Equipment).Where(l => l.Id == id.Value).FirstOrDefault();

        public void Update(LastRepair item) => _context.Entry(item).State = EntityState.Modified;

    }
}
