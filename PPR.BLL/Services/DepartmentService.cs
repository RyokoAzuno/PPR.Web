using AutoMapper;
using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentDTO, Department>()).CreateMapper();
            Department d = mapper.Map<DepartmentDTO, Department>(dep);
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Department>, List<DepartmentDTO>>(DB.Departments.GetAll());
        }

        public DepartmentDTO GetDepartment(int? id)
        {
            var department = DB.Departments.GetById(id.Value);
            return new DepartmentDTO
            {
               Id = department.Id,
               Code = department.Code,
               Name = department.Name,
               NumberOfBrigades = department.NumberOfBrigades
            };
        }

        public void UpdateDepartment(DepartmentDTO dep)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentDTO, Department>()).CreateMapper();
            Department d = mapper.Map<DepartmentDTO, Department>(dep);
            DB.Departments.Update(d);
            DB.Commit();
        }
    }
}
