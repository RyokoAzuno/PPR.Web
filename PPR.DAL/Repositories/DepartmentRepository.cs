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
    public class DepartmentRepository : IRepository<Department>
    {
        private PPRContext _context;

        public DepartmentRepository(PPRContext context)
        {
            _context = context;
        }

        public void Create(Department item)
        {
            item.NumberOfBrigades = 0;
            _context.Departments.Add(item);
        }

        public void Delete(int id)
        {
            //Department dep = _context.Departments.Find(id);
            Department dep = _context.Departments.Where(d => d.Code == id).FirstOrDefault();
            if (dep != null)
            {
                //IEnumerable<Brigade> brigades = _context.Brigades.Where(b => b.DepartmentId == dep.Id).ToList();
                IEnumerable<Brigade> brigades = _context.Brigades.Where(b => b.Department.Code == dep.Code).ToList();
                _context.Brigades.RemoveRange(brigades);
                //_context.Database.ExecuteSqlCommand("ALTER TABLE dbo.Brigades ADD CONSTRAINT Brigades_Departments FOREIGN KEY (DepartmentId) REFERENCES dbo.Departments (Id) ON DELETE SET NULL");
                _context.Departments.Remove(dep);
            }
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.Include(d => d.Brigades).ToList();
        }

        public Department GetById(int? id)
        {
            //return _context.Departments.Find(id.Value);
            return _context.Departments.Where(d => d.Code == id.Value).FirstOrDefault();
        }


        public void Update(Department item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
