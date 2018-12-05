using PPR.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDTO GetDepartment(int? id);
        void CreateDepartment(DepartmentDTO dep);
        void UpdateDepartment(DepartmentDTO dep);
        void DeleteDepartment(int id);
    }
}
