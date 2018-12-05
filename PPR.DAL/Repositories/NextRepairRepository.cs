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
    public class NextRepairRepository : IRepository<NextRepair>
    {
        private PPRContext _context;

        public NextRepairRepository(PPRContext context)
        {
            _context = context;
        }
        public void Create(NextRepair item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NextRepair> GetAll() => _context.NextRepairs.Include(n => n.Equipment).ToArray();

        public NextRepair GetById(int? id) => _context.NextRepairs.Where(n => n.Id == id.Value).FirstOrDefault();

        public void Update(NextRepair item) => _context.Entry(item).State = EntityState.Modified;

    }
}
