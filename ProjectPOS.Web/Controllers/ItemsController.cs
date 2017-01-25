using MiniProjectPOS.DAL;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPOS.Web.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search() 
        {
            return PartialView("List", ItemsDAL.GetAll());
        }

        public ActionResult Create() 
        {
            ViewBag.ListCategory = new SelectList(CategoryDAL.GetAll(), "ID", "Name");
            return PartialView();
        }

        public ActionResult ItemVarians()
        {
            List<ItemsVariantViewModel> model = new List<ItemsVariantViewModel>();
            return PartialView("ItemVarians", model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListCategory = new SelectList(CategoryDAL.GetAll(), "ID", "Name");
            return PartialView("Edit", ItemsDAL.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemsViewModel model) 
        {
            if (ModelState.IsValid)
            {
                if (ItemsDAL.Edit(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

        public ActionResult AddVariant() 
        {
            return PartialView();
        }

        public ActionResult AddInventory() {
            return PartialView();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ItemsDAL.Add(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }
    }
}