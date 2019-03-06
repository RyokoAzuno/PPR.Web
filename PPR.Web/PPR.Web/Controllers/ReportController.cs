using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
using PPR.CrossCutting.Utils;
using PPR.Web.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPR.Web.Controllers
{
    [Authorize(Users = "admin, user")]
    public class ReportController : Controller
    {
        IRepairReport<LastRepairReportInfoDTO> _lastRepairReport;
        IRepairReport<NextRepairReportInfoDTO> _nextRepairReport;
        IEquipmentService _equipmentService;
        IDepartmentService _departmentService;
        ILastRepairService _lastRepairService;
        INextRepairService _nextRepairService;
        int PAGE_SIZE = 5;

        public ReportController(IRepairReport<LastRepairReportInfoDTO> lastRepairReport,
                                IRepairReport<NextRepairReportInfoDTO> nextRepairReport,
                                IEquipmentService equipmentService, IDepartmentService departmentService,
                                ILastRepairService lastRepairService, INextRepairService nextRepairService)
        {
            _equipmentService = equipmentService;
            _departmentService = departmentService;
            _lastRepairReport = lastRepairReport;
            _nextRepairReport = nextRepairReport;
            _lastRepairService = lastRepairService;
            _nextRepairService = nextRepairService;
        }
        // GET: Report
        public ActionResult Index(int page = 1)
        {
            IEnumerable<EquipmentDTO> equipmentsDto = _equipmentService.GetAllEquipments();
            var equipments = MyMapper<EquipmentDTO, EquipmentViewModel>.Map(equipmentsDto)
                                                                .OrderBy(b => b.Id)
                                                                .Skip((page - 1) * PAGE_SIZE)
                                                                .Take(PAGE_SIZE);
            PageViewModel<EquipmentViewModel> p = new PageViewModel<EquipmentViewModel>
            {
                Items = equipments,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = _equipmentService.GetAllEquipments().Count()
                }
            };
            return View(p);
        }

        public ActionResult LastRepair(int id)
        {
            LastRepairReportInfoDTO reportDto = _lastRepairReport.GetReport(id);
            var report = MyMapper<LastRepairReportInfoDTO, LastRepairReportInfoViewModel>.Map(reportDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }

        public ActionResult NextRepair(int id)
        {
            NextRepairReportInfoDTO reportDto = _nextRepairReport.GetReport(id);
            var report = MyMapper<NextRepairReportInfoDTO, NextRepairReportInfoViewModel>.Map(reportDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }

        public ActionResult LastRepairs()
        {
            IEnumerable<LastRepairDTO> lastRepairsDto = _lastRepairService.GetAllLastRepairs();
            var report = MyMapper<LastRepairDTO, LastRepairViewModel>.Map(lastRepairsDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }

        public ActionResult NextRepairs()
        {
            IEnumerable<NextRepairDTO> nextRepairsDto = _nextRepairService.GetAllNextRepairs();
            var report = MyMapper<NextRepairDTO, NextRepairViewModel>.Map(nextRepairsDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }

        public ActionResult Departments()
        {
            IEnumerable<DepartmentDTO> departmentsDto = _departmentService.GetAllDepartments();
            var report = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentsDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }

        public ActionResult DepartmentsAndEquipments()
        {
            IEnumerable<DepartmentDTO> departmentsDto = _departmentService.GetAllDepartments();
            var report = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentsDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }
        
        public ActionResult DepartmentsAndBrigades()
        {
            IEnumerable<DepartmentDTO> departmentsDto = _departmentService.GetAllDepartments();
            var report = MyMapper<DepartmentDTO, DepartmentViewModel>.Map(departmentsDto);
            if (report != null)
                return View(report);
            else
                return HttpNotFound();
        }
        // Save view as pdf document
        public ActionResult SaveAsPdf(string viewName)
        {
            return new ActionAsPdf(viewName);
        }
    }
}
