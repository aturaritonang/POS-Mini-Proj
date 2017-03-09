using MiniProjectPOS.DAL;
using MiniProjectPOS.ViewModel;
using ProjectPOS.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPOS.Web.Controllers
{
    [CustomAuthorize(Roles = "Administrator, Back Office")]
    public class CategoryController : Controller
    {
        private int outletId = int.Parse(SessionPersister.Outlet);
        // GET: Category

        //[SessionExpireFilter]
        public ActionResult Index()
        {
            return View(CategoryDAL.GetAllByOutletId(outletId));
        }

        public ActionResult Search(string strSearch) 
        {
            return PartialView("List", CategoryDAL.GetAllBySearch(strSearch, outletId));
        }

        [CustomAuthorize(Roles = "Back Office")]
        public ActionResult Create() 
        {
            return PartialView("Create");
        }

        [CustomAuthorize(Roles = "Back Office")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model) 
        {
            if (CategoryDAL.Add(model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return PartialView("Create", model);
            }
        }

        //[CustomAuthorize(Roles = "Back Office")]
        public ActionResult Edit(int id) 
        {
            return PartialView("Edit", CategoryDAL.GetById(id));
        }

        //[CustomAuthorize(Roles = "Back Office")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (CategoryDAL.Update(model))
            {
                return RedirectToAction("Index", new { Message = "Yes" });
            }
            else 
            {
                return PartialView("Edit", model);
            }
        }

        [CustomAuthorize(Roles = "Back Office")]
        public ActionResult Delete(int id)
        {
            return PartialView(CategoryDAL.GetById(id));
        }

        [CustomAuthorize(Roles = "Back Office")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel model) 
        {
            if (CategoryDAL.Delete(model.ID))
            {
                ViewBag.ActionStatus = "Saved";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ActionStatus = "Error";
                return PartialView("Delete", model);
            }
        }
    }
}