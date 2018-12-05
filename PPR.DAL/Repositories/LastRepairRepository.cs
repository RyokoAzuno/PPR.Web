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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LastRepair> GetAll() => _context.LastRepairs.Include(l => l.Equipment).ToArray();

        public LastRepair GetById(int? id) => _context.LastRepairs.Where(l => l.Id == id.Value).FirstOrDefault();

        public void Update(LastRepair item) => _context.Entry(item).State = EntityState.Modified;

    }
}
