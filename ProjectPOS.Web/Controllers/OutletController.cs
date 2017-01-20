using MiniProjectPOS.DAL;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPOS.Web.Controllers
{
    public class OutletController : Controller
    {
        // GET: Outlet
        public ActionResult Index()
        {
            return View(OutletDAL.GetAll());
        }

        public ActionResult Search(string strSearch) 
        {
            return PartialView("List", OutletDAL.GetAllBySearch(strSearch));
        }

        public ActionResult Create()
        {
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OutletViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (OutletDAL.Add(model))
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            OutletViewModel model = OutletDAL.GetById(id);
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            ViewBag.RegionList = new SelectList(RegionDAL.GetByProvinceId(model.ProvinceID), "ID", "RegionName");
            ViewBag.DistrictList = new SelectList(DistrictDAL.GetByRegionId(model.RegionID), "ID", "DistrictName");
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OutletViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (OutletDAL.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            return PartialView("Delete", OutletDAL.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (OutletDAL.Delete(model.ID))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Delete", model);
        }
    }
}