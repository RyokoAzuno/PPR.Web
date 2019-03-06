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
    public class BrigadeRepository : IRepository<Brigade>
    {
        private PPRContext _context;

        public BrigadeRepository(PPRContext context)
        {
            _context = context;
        }

        public void Create(Brigade item)
        {
            //Department department = _context.Departments.Find(item.DepartmentId);
            Department department = _context.Departments.Where(d => d.Code == item.Department.Code).FirstOrDefault();
            item.Department = department;
            ++department.NumberOfBrigades;
            _context.Brigades.Add(item);
        }

        public void Delete(int id)
        {
            Brigade brigade = _context.Brigades.Include(d => d.Department).Where(b => b.Id == id).FirstOrDefault();
            if (brigade != null)
            {
                //Department department = _context.Departments.Find(brigade.DepartmentId);
                brigade.Department.NumberOfBrigades--; 
                _context.Brigades.Remove(brigade);
            }
        }

        public IEnumerable<Brigade> GetAll()
        {
            return _context.Brigades.Include(b => b.Department).ToList();
        }

        public Brigade GetById(int? id)
        {
            return _context.Brigades.Include(b => b.Department).Where(b => b.Id == id.Value).FirstOrDefault();
        }

        public void Update(Brigade item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
