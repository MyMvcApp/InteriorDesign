using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteriorDesign.Common.Controllers;
using Newtonsoft.Json;
namespace InteriorDesign.Commom.Controllers.Controllers.End.Common
{
    public class HomeController : BaseController
    {
         [HttpGet]
        public ActionResult Index()
        {
            if(CheckIfLogin())
            {
                ViewBag.LoginName = CurrentEndUser.AdminName;
                ViewBag.User = JsonConvert.SerializeObject(new { AdminUserID = CurrentEndUser.ID,
                                                                    AdminName = CurrentEndUser.AdminName,
                                                                    RealName = CurrentEndUser.RealName,
                                                                    AdminType = CurrentEndUser.AdminType
                });
                return View();
            }
            return RedirectToAction("Login", "Account", new { Area = "AdminEnd" });
        }

         [HttpGet]
        public ActionResult Top()
        {
            return View();
        }

         [HttpGet]
        public ActionResult Menu()
        {
            return View();
        }

         [HttpGet]
        public ActionResult Bottom()
        {
            return View();
        }
    }
}
