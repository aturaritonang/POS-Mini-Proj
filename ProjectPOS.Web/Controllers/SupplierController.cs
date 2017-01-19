using MiniProjectPOS.DAL;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPOS.Web.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View(SupplierDAL.GetAll());
        }

        public ActionResult Search(string strSearch)
        {
            return PartialView("List", SupplierDAL.GetAllBySearch(strSearch));
        }
        public ActionResult Create() 
        {
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierViewModel model) {
            if (ModelState.IsValid)
            {
                if (SupplierDAL.Add(model))
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Edit", SupplierDAL.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (SupplierDAL.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProvinceList = new SelectList(ProvinceDAL.GetAll(), "ID", "ProvinceName");
            return PartialView("Edit", model);
        }

        public ActionResult Delete(int id) 
        {
            return PartialView("Delete", SupplierDAL.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SupplierViewModel model) 
        {
            if (ModelState.IsValid)
            {
                if (SupplierDAL.Delete(model.ID))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Delete", model);
        }
    }
}