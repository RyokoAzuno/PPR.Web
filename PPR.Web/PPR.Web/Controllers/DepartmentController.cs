using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
using PPR.CrossCutting.Utils;
using PPR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPR.Web.Controllers
{
    [Authorize(Users = "admin")]
    public class DepartmentController : Controller
    {
        IDepartmentService _departmentService;
        int PAGE_SIZE = 5;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        #region Departments
        public ActionResult Departments(int page = 1)
        {
            IEnumerable<DepartmentDTO> departmentsDto = _departmentService.GetAllDepartments();
            var departments = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentsDto)
                                                                .OrderBy(b => b.Id)
                                                                .Skip((page - 1) * PAGE_SIZE)
                                                                .Take(PAGE_SIZE);
            PageViewModel<DepartmentViewModel> p = new PageViewModel<DepartmentViewModel>
            {
                Items = departments,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = _departmentService.GetAllDepartments().Count()
                }
            };

            return View(p);
        }

        [HttpGet]
        public ActionResult EditDepartment(int id, int code)
        {
            DepartmentDTO departmentDTO = _departmentService.GetDepartment(code);
            if (departmentDTO != null)
            {
                var department = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentDTO);

                return View(department);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditDepartment(DepartmentViewModel department)
        {
            if (department != null)
            {
                var departmentDTO = MyMapper<DepartmentViewModel, DepartmentDTO>.Map(department);
                _departmentService.UpdateDepartment(departmentDTO);

                return RedirectToAction("Departments");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(DepartmentViewModel department)
        {
            if (department != null)
            {
                var departmentDTO = MyMapper<DepartmentViewModel, DepartmentDTO>.Map(department);
                _departmentService.CreateDepartment(departmentDTO);

                return RedirectToAction("Departments");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteDepartment(int id, int code)
        {
            DepartmentDTO departmentDTO = _departmentService.GetDepartment(code);
            if (departmentDTO != null)
            {
                var department = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentDTO);

                return View(department);
            }
            return HttpNotFound();
        }
        [HttpPost, ActionName("DeleteDepartment")]
        public ActionResult ConfirmDepartmentDeletion(int id, int code)
        {
            DepartmentDTO departmentDTO = _departmentService.GetDepartment(code);
            if (departmentDTO != null)
            {
                _departmentService.DeleteDepartment(code);
                return RedirectToAction("Departments");
            }
            return HttpNotFound();
        }
        #endregion

    }
}