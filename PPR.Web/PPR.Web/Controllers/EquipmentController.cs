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
    public class EquipmentController : Controller
    {
        IEquipmentService _equipmentService;
        int PAGE_SIZE = 5;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        public ActionResult Equipments(int page = 1)
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
        [HttpGet]
        public ActionResult EditEquipment(int id/*, string inventoryNumber*/)
        {
            EquipmentDTO equipmentDTO = _equipmentService.GetEquipment(id);//.GetAllEquipments().Where(e => e.InventoryNumber == inventoryNumber).FirstOrDefault();
            if (equipmentDTO != null)
            {
                var equipment = MyMapper<EquipmentDTO, EquipmentViewModel>.Map(equipmentDTO);

                return View(equipment);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditEquipment(EquipmentViewModel equipment)
        {
            if (equipment != null)
            {
                var equipmentDTO = MyMapper<EquipmentViewModel, EquipmentDTO>.Map(equipment);
                _equipmentService.UpdateEquipment(equipmentDTO);

                return RedirectToAction("Equipments");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateEquipment()
        {
            var lst = _equipmentService.GetDepartmentsNamesAndCodes();
            SelectList departments = new SelectList(lst, "Id", "Name", 1);
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult CreateEquipment(EquipmentViewModel equipment)
        {
            if (equipment != null)
            {
                var equipmentDTO = MyMapper<EquipmentViewModel, EquipmentDTO>.Map(equipment);
                _equipmentService.CreateEquipment(equipmentDTO);

                return RedirectToAction("Equipments");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteEquipment(int id)
        {
            EquipmentDTO equipmentDTO = _equipmentService.GetEquipment(id);
            if (equipmentDTO != null)
            {
                var equipment = MyMapper<EquipmentDTO, EquipmentViewModel>.Map(equipmentDTO);

                return View(equipment);
            }
            return HttpNotFound();
        }
        [HttpPost, ActionName("DeleteEquipment")]
        public ActionResult ConfirmEquipmentDeletion(int id)
        {
            _equipmentService.DeleteEquipment(id);
            return RedirectToAction("Equipments");
        }

    }
}