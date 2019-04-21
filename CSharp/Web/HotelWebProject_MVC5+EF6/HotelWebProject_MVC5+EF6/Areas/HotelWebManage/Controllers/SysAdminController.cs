using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;

namespace HotelWebProject_MVC5_EF6.Areas.HotelWebManage.Controllers
{
    public class SysAdminController : Controller
    {
        private SysAdminsManager objSysAdminsManager = new SysAdminsManager();
        // GET: HotelWebManage/SysAdmin
        public ActionResult Index()
        {
            return View("AdminLogin");
        }
        // 不能加[Authorize]，这是默认导航页面
        public ActionResult AdminLogin(SysAdmins admins)
        {
            if (ModelState.IsValid)
            {
                admins = objSysAdminsManager.AdminLogin(admins);
                if (admins == null)
                {
                    ViewBag.LoginError = true;
                    return View("AdminLogin", admins);
                }
                else
                {
                    ViewBag.LoginError = false;
                    Session["currentAdminName"] = admins.LoginName;
                    FormsAuthentication.SetAuthCookie(admins.LoginName, true);
                    return View("AdminMain");
                }
            }
            return View("AdminLogin");
        }

        [Authorize]
        public ActionResult AdminMain()
        {
            return View();
        }

        [Authorize]
        public ActionResult ExitSys()
        {
            Session["currentAdminName"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("AdminLogin");
        }
    }
}