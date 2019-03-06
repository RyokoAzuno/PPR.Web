using PPR.BLL.DataTransferObjects;
using PPR.BLL.Interfaces;
using PPR.CrossCutting.Utils;
using PPR.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace PPR.Web.Controllers
{
    [Authorize(Users = "admin")]
    public class BrigadeController : Controller
    {
        IBrigadeService _brigadeService;
        const int PAGE_SIZE = 5;

        public BrigadeController(IBrigadeService brigadeService)
        {
            _brigadeService = brigadeService;
        }

        #region Brigades
        public ActionResult Brigades(int page = 1)
        {
            IEnumerable<BrigadeDTO> brigadesDto = _brigadeService.GetAllBrigades();
            var brigades = MyMapper<BrigadeDTO, BrigadeViewModel>.Map(brigadesDto)
                                                                .OrderBy(b => b.Id)
                                                                .Skip((page - 1) * PAGE_SIZE)
                                                                .Take(PAGE_SIZE);
            PageViewModel<BrigadeViewModel> p = new PageViewModel<BrigadeViewModel>
            {
                Items = brigades,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = _brigadeService.GetAllBrigades().Count()
                }
            };
            return View(p);
        }
        [HttpGet]
        public ActionResult EditBrigade(int id)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(id);
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
            var lst = _brigadeService.GetDepartmentsNamesAndCodes();
            SelectList departments = new SelectList(lst, "Code", "Name", "30");
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult CreateBrigade(BrigadeViewModel brigade)
        {
            if (ModelState.IsValid)
            {
                if (brigade != null)
                {
                    var brigadeDTO = MyMapper<BrigadeViewModel, BrigadeDTO>.Map(brigade);
                    _brigadeService.CreateBrigade(brigadeDTO);

                    return RedirectToAction("Brigades");
                }
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteBrigade(int id)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(id);
            if (brigadeDTO != null)
            {
                var brigade = MyMapper<BrigadeDTO, BrigadeViewModel>.Map(brigadeDTO);
                return View(brigade);
            }
            return HttpNotFound();
        }
        [HttpPost, ActionName("DeleteBrigade")]
        public ActionResult ConfirmBrigadeDeletion(int id)
        {
            BrigadeDTO brigadeDTO = _brigadeService.GetBrigade(id);
            if (brigadeDTO != null)
            {
                _brigadeService.DeleteBrigade(id);
                return RedirectToAction("Brigades");
            }
            return HttpNotFound();
        }
        #endregion

    }
}
