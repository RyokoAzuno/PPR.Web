using AutoMapper;
using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
using PPR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPR.Web.Controllers
{
    public class HomeController : Controller
    {
        IBrigadeService _brigadeService;
        IDepartmentService _departmentService;
        IEquipmentService _equipmentService;
        ILastRepairService _lastRepairService;
        INextRepairService _nextRepairService;

        public HomeController(IBrigadeService brigadeService, IDepartmentService departmentService, IEquipmentService equipmentService, ILastRepairService lastRepairService, INextRepairService nextRepairService)
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeDTO, BrigadeViewModel>()).CreateMapper();
            var brigades = mapper.Map<IEnumerable<BrigadeDTO>, List<BrigadeViewModel>>(brigadesDto);

            return View(brigades);
        }
        [HttpGet]
        public ActionResult EditBrigade(int id, int code)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(code);
            if (brigadeDTO != null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeDTO, BrigadeViewModel>()).CreateMapper();
                var brigade = mapper.Map<BrigadeDTO, BrigadeViewModel>(brigadeDTO);

                return View(brigade);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBrigade(BrigadeViewModel brigade)
        {
            if (brigade != null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeViewModel, BrigadeDTO>()).CreateMapper();
                var brigadeDTO = mapper.Map<BrigadeViewModel, BrigadeDTO>(brigade);
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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeViewModel, BrigadeDTO>()).CreateMapper();
                var brigadeDTO = mapper.Map<BrigadeViewModel, BrigadeDTO>(brigade);
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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrigadeDTO, BrigadeViewModel>()).CreateMapper();
                var brigade = mapper.Map<BrigadeDTO, BrigadeViewModel>(brigadeDTO);
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentDTO, DepartmentViewModel>()).CreateMapper();
            var departments = mapper.Map<IEnumerable<DepartmentDTO>, List<DepartmentViewModel>>(departmentsDto);

            return View(departments);
        }
       
        [HttpGet]
        public ActionResult EditDepartment(int id, int code)
        {
            DepartmentDTO departmentDTO = _departmentService.GetDepartment(code);
            if(departmentDTO != null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentDTO, DepartmentViewModel>()).CreateMapper();
                var department = mapper.Map<DepartmentDTO, DepartmentViewModel>(departmentDTO);

                return View(department);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditDepartment(DepartmentViewModel department)
        {
            if(department != null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentViewModel, DepartmentDTO>()).CreateMapper();
                var departmentDTO = mapper.Map<DepartmentViewModel, DepartmentDTO>(department);
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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentViewModel, DepartmentDTO>()).CreateMapper();
                var departmentDTO = mapper.Map<DepartmentViewModel, DepartmentDTO>(department);
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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentDTO, DepartmentViewModel>()).CreateMapper();
                var department = mapper.Map<DepartmentDTO, DepartmentViewModel>(departmentDTO);
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EquipmentDTO, EquipmentViewModel>()).CreateMapper();
            var equipments = mapper.Map<IEnumerable<EquipmentDTO>, List<EquipmentViewModel>>(brigadesDto);

            return View(equipments);
        }
        #endregion

        #region LastRepairs
        public ActionResult LastRepairs()
        {
            IEnumerable<LastRepairDTO> brigadesDto = _lastRepairService.GetAllLastRepairs();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LastRepairDTO, LastRepairViewModel>()).CreateMapper();
            var lastRepairs = mapper.Map<IEnumerable<LastRepairDTO>, List<LastRepairViewModel>>(brigadesDto);

            return View(lastRepairs);
        }
        #endregion

        #region NextRepairs
        public ActionResult NextRepairs()
        {
            IEnumerable<NextRepairDTO> brigadesDto = _nextRepairService.GetAllNextRepairs();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NextRepairDTO, NextRepairViewModel>()).CreateMapper();
            var nextRepairs = mapper.Map<IEnumerable<NextRepairDTO>, List<NextRepairViewModel>>(brigadesDto);

            return View(nextRepairs);
        }
        #endregion
    }
}