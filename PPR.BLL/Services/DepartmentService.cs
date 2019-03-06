using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
using PPR.CrossCutting.Utils;
using PPR.DAL.Entities;
using PPR.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork DB { get; set; }

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }

        public void CreateDepartment(DepartmentDTO dep)
        {
            Department d = MyMapper<DepartmentDTO, Department>.Map(dep); 
            DB.Departments.Create(d);
            DB.Commit();
        }

        public void DeleteDepartment(int id)
        {
            DB.Departments.Delete(id);
            DB.Commit();
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            return MyMapper<Department, DepartmentDTO>.Map(DB.Departments.GetAll());
        }

        public DepartmentDTO GetDepartment(int? id)
        {
            //var department = DB.Departments.GetById(id.Value);
            //return new DepartmentDTO
            //{
            //   Id = department.Id,
            //   Code = department.Code,
            //   Name = department.Name,
            //   NumberOfBrigades = department.NumberOfBrigades
            //};
            return MyMapper<Department, DepartmentDTO>.Map(DB.Departments.GetById(id.Value));
        }

        public void UpdateDepartment(DepartmentDTO dep)
        {
            Department d = MyMapper<DepartmentDTO, Department>.Map(dep);
            DB.Departments.Update(d);
            DB.Commit();
        }
    }
}
