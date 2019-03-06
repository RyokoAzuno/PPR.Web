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
    public class NextRepairController : Controller
    {
        INextRepairService _nextRepairService;
        int PAGE_SIZE = 5;

        public NextRepairController(INextRepairService nextRepairService)
        {
            _nextRepairService = nextRepairService;
        }

        public ActionResult NextRepairs(int page = 1)
        {
            IEnumerable<NextRepairDTO> nextRepairsDto = _nextRepairService.GetAllNextRepairs();
            var nextRepairs = MyMapper<NextRepairDTO, NextRepairViewModel>.Map(nextRepairsDto)
                                                                .OrderBy(b => b.Id)
                                                                .Skip((page - 1) * PAGE_SIZE)
                                                                .Take(PAGE_SIZE);
            PageViewModel<NextRepairViewModel> p = new PageViewModel<NextRepairViewModel>
            {
                Items = nextRepairs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = _nextRepairService.GetAllNextRepairs().Count()
                }
            };
            return View(p);
        }

        [HttpGet]
        public ActionResult EditNextRepair(int id)
        {
            NextRepairDTO nextRepairDTO = _nextRepairService.GetNextRepair(id);
            if (nextRepairDTO != null)
            {
                ViewBag.Repairs = new SelectList(_nextRepairService.GetRepairTypes(), 1);
                ViewBag.Technicians = new SelectList(_nextRepairService.GetTechniciansNames(), 1);
                var nextRepair = MyMapper<NextRepairDTO, NextRepairViewModel>.Map(nextRepairDTO);
                return View(nextRepair);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditNextRepair(NextRepairViewModel nextRepair)
        {
            if (nextRepair != null)
            {
                var nextRepairDTO = MyMapper<NextRepairViewModel, NextRepairDTO>.Map(nextRepair);
                _nextRepairService.UpdateNextRepair(nextRepairDTO);
                return RedirectToAction("NextRepairs");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateNextRepair()
        {
            var lst = _nextRepairService.GetEquipmentsIdsAndNames();
            SelectList equipments = new SelectList(lst, "Id", "Name", 1);
            ViewBag.Equipments = equipments;
            ViewBag.Repairs = new SelectList(_nextRepairService.GetRepairTypes(), 1);
            ViewBag.Technicians = new SelectList(_nextRepairService.GetTechniciansNames(), 1);
            return View();
        }
        [HttpPost]
        public ActionResult CreateNextRepair(NextRepairViewModel nextRepair)
        {
            if (nextRepair != null)
            {
                var nextRepairDTO = MyMapper<NextRepairViewModel, NextRepairDTO>.Map(nextRepair);
                _nextRepairService.CreateNextRepair(nextRepairDTO);
                return RedirectToAction("NextRepairs");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteNextRepair(int id)
        {
            NextRepairDTO nextRepairDTO = _nextRepairService.GetNextRepair(id);
            if (nextRepairDTO != null)
            {
                var nextRepair = MyMapper<NextRepairDTO, NextRepairViewModel>.Map(nextRepairDTO);
                return View(nextRepair);
            }
            return HttpNotFound();
        }
        [HttpPost, ActionName("DeleteNextRepair")]
        public ActionResult ConfirmNextRepairDeletion(int id)
        {
            NextRepairDTO nextRepairDTO = _nextRepairService.GetNextRepair(id);
            if (nextRepairDTO != null)
            {
                _nextRepairService.DeleteNextRepair(id);
                return RedirectToAction("NextRepairs");
            }
            return HttpNotFound();
        }
    }
}