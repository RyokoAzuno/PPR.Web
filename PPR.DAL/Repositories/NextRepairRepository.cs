﻿using PPR.DAL.EFContext;
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
            if (item != null)
                _context.NextRepairs.Add(item);
        }

        public void Delete(int id)
        {
            NextRepair nr = _context.NextRepairs.Where(n => n.Id == id).FirstOrDefault();
            if (nr != null)
                _context.NextRepairs.Remove(nr);
        }

        public IEnumerable<NextRepair> GetAll() => _context.NextRepairs.Include(n => n.Equipment).ToArray();

        public NextRepair GetById(int? id) => _context.NextRepairs.Include(n => n.Equipment).Where(n => n.Id == id.Value).FirstOrDefault();

        public void Update(NextRepair item) => _context.Entry(item).State = EntityState.Modified;

    }
}
