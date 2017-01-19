using MiniProjectPOS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPOS.Web.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Province
        public ActionResult Index()
        {
            return View(ProvinceDAL.GetAll());
        }
    }
}