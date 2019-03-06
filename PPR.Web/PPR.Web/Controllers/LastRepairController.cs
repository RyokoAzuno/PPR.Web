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
    public class LastRepairController : Controller
    {
        ILastRepairService _lastRepairService;
        int PAGE_SIZE = 5;

        public LastRepairController(ILastRepairService lastRepairService)
        {
            _lastRepairService = lastRepairService;
        }
     
        public ActionResult LastRepairs(int page = 1)
        {
            IEnumerable<LastRepairDTO> lastRepairsDto = _lastRepairService.GetAllLastRepairs();
            var lastRepairs = MyMapper<LastRepairDTO, LastRepairViewModel>.Map(lastRepairsDto)
                                                                .OrderBy(b => b.Id)
                                                                .Skip((page - 1) * PAGE_SIZE)
                                                                .Take(PAGE_SIZE);
            PageViewModel<LastRepairViewModel> p = new PageViewModel<LastRepairViewModel>
            {
                Items = lastRepairs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = _lastRepairService.GetAllLastRepairs().Count()
                }
            };
            return View(p);
        }

        [HttpGet]
        public ActionResult EditLastRepair(int id)
        {
            LastRepairDTO lastRepairDTO = _lastRepairService.GetLastRepair(id);
            if (lastRepairDTO != null)
            {
                ViewBag.Repairs = new SelectList(_lastRepairService.GetRepairTypes(), 1);
                ViewBag.Technicians = new SelectList(_lastRepairService.GetTechniciansNames(), 1);
                var lastRepair = MyMapper<LastRepairDTO, LastRepairViewModel>.Map(lastRepairDTO);
                return View(lastRepair);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditLastRepair(LastRepairViewModel lastRepair)
        {
            if (lastRepair != null)
            {
                var lastRepairDTO = MyMapper<LastRepairViewModel, LastRepairDTO>.Map(lastRepair);
                _lastRepairService.UpdateLastRepair(lastRepairDTO);

                return RedirectToAction("LastRepairs");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateLastRepair()
        {
            var lst = _lastRepairService.GetEquipmentsIdsAndNames();
            SelectList equipments = new SelectList(lst, "Id", "Name", 1);
            ViewBag.Equipments = equipments;
            ViewBag.Repairs = new SelectList(_lastRepairService.GetRepairTypes(), 1);
            ViewBag.Technicians = new SelectList(_lastRepairService.GetTechniciansNames(), 1);
            return View();
        }
        [HttpPost]
        public ActionResult CreateLastRepair(LastRepairViewModel lastRepair)
        {
            if (lastRepair != null)
            {
                var lastRepairDTO = MyMapper<LastRepairViewModel, LastRepairDTO>.Map(lastRepair);
                _lastRepairService.CreateLastRepair(lastRepairDTO);

                return RedirectToAction("LastRepairs");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteLastRepair(int id)
        {
            LastRepairDTO lastRepairDTO = _lastRepairService.GetLastRepair(id);
            if (lastRepairDTO != null)
            {
                var lastRepair = MyMapper<LastRepairDTO, LastRepairViewModel>.Map(lastRepairDTO);
                return View(lastRepair);
            }
            return HttpNotFound();
        }
        [HttpPost, ActionName("DeleteLastRepair")]
        public ActionResult ConfirmLastRepairDeletion(int id)
        {
            LastRepairDTO lastRepairDTO = _lastRepairService.GetLastRepair(id);
            if (lastRepairDTO != null)
            {
                _lastRepairService.DeleteLastRepair(id);
                return RedirectToAction("LastRepairs");
            }
            return HttpNotFound();
        }
    }
}