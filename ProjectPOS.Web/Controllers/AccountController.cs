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
    public class AccountController : Controller
    {
        private AccountViewModel accountViewModel = new AccountViewModel();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountViewModel model) 
        {
            AccountDAL aDal = new AccountDAL();
            AccountViewModel avm = AccountDAL.GetByUserNamePassword(model.Username, model.Password);

            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password) || avm == null)
            {
                ViewBag.Error = "Account is invalid.";
                return View("Index", model);
            }

            SessionPersister.Username = avm.Username;
            SessionPersister.RoleId = avm.RoleID.ToString();
            return RedirectToAction("SetOutlet");
        }

        public ActionResult SetOutlet()
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
                return RedirectToAction("Index");

            List<OutletViewModel> outletList = OutletDAL.GetAll();
            if (SessionPersister.Username == "admin")
                outletList.Add(new OutletViewModel { ID = 0, OutletName = "All outlet" });

            ViewBag.LIstOutlet = new SelectList(outletList, "ID", "OutletName");
            return View(accountViewModel);
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetOutlet(AccountViewModel model)
        {
            SessionPersister.Outlet = model.OutletId.ToString();
            return RedirectToAction("Index", "Home");
        }
    }
}