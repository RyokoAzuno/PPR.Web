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
    public class InitialController : Controller
    {
        IBrigadeService _brigadeService;
        IDepartmentService _departmentService;
        IEquipmentService _equipmentService;
        ILastRepairService _lastRepairService;
        INextRepairService _nextRepairService;

        public InitialController(IBrigadeService brigadeService, IDepartmentService departmentService, IEquipmentService equipmentService, ILastRepairService lastRepairService, INextRepairService nextRepairService)
        {
            _brigadeService = brigadeService;
            _departmentService = departmentService;
            _equipmentService = equipmentService;
            _lastRepairService = lastRepairService;
            _nextRepairService = nextRepairService;
        }

        #region Brigades
        public ActionResult Brigades()
        {
            IEnumerable<BrigadeDTO> brigadesDto = _brigadeService.GetAllBrigades();
            var brigades = MyMapper<BrigadeDTO, BrigadeViewModel>.Map(brigadesDto);
            return View(brigades);
        }
        [HttpGet]
        public ActionResult EditBrigade(int id, int code)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(code);
            if (brigadeDTO != null)
            {
                var brigade = MyMapper<BrigadeDTO, BrigadeViewModel>.Map(brigadeDTO);
                return View(brigade);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBrigade(BrigadeViewModel brigade)
        {
            if (brigade != null)
            {
                var brigadeDTO = MyMapper<BrigadeViewModel, BrigadeDTO>.Map(brigade);
                _brigadeService.UpdateBrigade(brigadeDTO);

                return RedirectToAction("Brigades");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateBrigade()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBrigade(BrigadeViewModel brigade)
        {
            if (brigade != null)
            {
                var brigadeDTO = MyMapper<BrigadeViewModel, BrigadeDTO>.Map(brigade);
                _brigadeService.CreateBrigade(brigadeDTO);

                return RedirectToAction("Brigades");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteBrigade(int id, int code)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(code);
            if (brigadeDTO != null)
            {
                var brigade = MyMapper<BrigadeDTO, BrigadeViewModel>.Map(brigadeDTO);
                return View(brigade);
            }
            return HttpNotFound();
        }
        [HttpPost, ActionName("DeleteBrigade")]
        public ActionResult ConfirmBrigadeDeletion(int id, int code)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(code);
            if (brigadeDTO != null)
            {
                _brigadeService.DeleteBrigade(code);
                return RedirectToAction("Brigades");
            }
            return HttpNotFound();
        }
        #endregion

        #region Departments
        public ActionResult Departments()
        {
            IEnumerable<DepartmentDTO> departmentsDto = _departmentService.GetAllDepartments();
            var departments = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentsDto);

            return View(departments);
        }
       
        [HttpGet]
        public ActionResult EditDepartment(int id, int code)
        {
            DepartmentDTO departmentDTO = _departmentService.GetDepartment(code);
            if(departmentDTO != null)
            {
                var department = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentDTO);

                return View(department);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditDepartment(DepartmentViewModel department)
        {
            if(department != null)
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

        #region Equipments
        public ActionResult Equipments()
        {
            IEnumerable<EquipmentDTO> brigadesDto = _equipmentService.GetAllEquipments();
            var equipments = MyMapper<EquipmentDTO, EquipmentViewModel>.Map(brigadesDto);

            return View(equipments);
        }
        #endregion

        #region LastRepairs
        public ActionResult LastRepairs()
        {
            IEnumerable<LastRepairDTO> lastRepairsDto = _lastRepairService.GetAllLastRepairs();
            var lastRepairs = MyMapper<LastRepairDTO, LastRepairViewModel>.Map(lastRepairsDto);

            return View(lastRepairs);
        }
        #endregion

        #region NextRepairs
        public ActionResult NextRepairs()
        {
            IEnumerable<NextRepairDTO> nextRepairsDto = _nextRepairService.GetAllNextRepairs();
            var nextRepairs = MyMapper<NextRepairDTO, NextRepairViewModel>.Map(nextRepairsDto);

            return View(nextRepairs);
        }
        #endregion
    }
}