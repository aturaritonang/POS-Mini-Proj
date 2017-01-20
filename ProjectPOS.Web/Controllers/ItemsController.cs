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

        public ActionResult ItemVarians()
        {
            List<ItemsVariantViewModel> model = new List<ItemsVariantViewModel>();
            return PartialView("ItemVarians", model);
        }
    }
}