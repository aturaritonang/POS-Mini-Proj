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
    [CustomAuthorize(Roles = "Administrator")]
    public class CategoryController : Controller
    {
        private int outletId = int.Parse(SessionPersister.Outlet);
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryDAL.GetAllByOutletId(outletId));
        }

        public ActionResult Search(string strSearch) 
        {
            return PartialView("List", CategoryDAL.GetAllBySearch(strSearch, outletId));
        }

        public ActionResult Create() 
        {
            return PartialView("Create");
        }

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

        public ActionResult Edit(int id) 
        {
            return PartialView("Edit", CategoryDAL.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (CategoryDAL.Update(model))
            {
                return RedirectToAction("Index");
            }
            else 
            {
                return PartialView("Edit", model);
            }
        }

        public ActionResult Delete(int id)
        {
            return PartialView(CategoryDAL.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel model) 
        {
            if (CategoryDAL.Delete(model.ID))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return PartialView("Delete", model);
            }
        }
    }
}