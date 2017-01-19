using MiniProjectPOS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPOS.Web.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProv()
        {
            return Json(ProvinceDAL.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegionByProv(int? id)
        {
            return Json(RegionDAL.GetByProvinceId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrictByRegion(int? id)
        {
            return Json(DistrictDAL.GetByRegionId(id), JsonRequestBehavior.AllowGet);
        }
    }
}