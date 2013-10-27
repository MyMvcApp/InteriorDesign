using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using InteriorDesign.Model.End;
using InteriorDesign.Repository.End;
using InteriorDesign.Context;
using InteriorDesign.Template;
using System.Linq.Expressions;
using PagedList;
using InteriorDesign.Helper;
using InteriorDesign.Controllers.Common;
using InteriorDesign.IRepository.End;
using System.Web.Security;
namespace InteriorDesign.Controllers.End.Controllers
{
    public class AccountController : BaseController
    {
        private IAdminUserRepository adminUserRepository;
        public AccountController()
        {
            adminUserRepository = new AdminUserRepository(new InteriorDesignContext());
        }

        [HttpGet]
        public ActionResult Login()
        {
            //如果是跳转过来的，则返回上一页面ReturnUrl
            if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
            {
                string returnUrl = Request["ReturnUrl"];
                ViewData["ReturnUrl"] = returnUrl;  //如果存在返回，则存在隐藏标签中
            }

            // 如果是登录状态，则条转到个人主页
            if (Session["admin"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(AdminUser model)
        {
            string msg = "";
            try
            {
                string pwd = WebHelper.GetMD5Hash(model.AdminPwd);
                Expression<Func<AdminUser, bool>> filter = null;
                if (!String.IsNullOrWhiteSpace(model.AdminName))
                    filter = d => d.AdminName.ToUpper().Equals(model.AdminName.ToUpper())
                        && d.AdminPwd.ToUpper().Equals(pwd);
                var adminUser = adminUserRepository.GetData(filter: filter).FirstOrDefault();
                if (adminUser!=null)
                {
                    FormsAuthentication.RedirectFromLoginPage(model.AdminName, false);
                    Session["admin"] = model.AdminName;
                    CurrentEndUser = adminUser;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "提供的用户名或密码不正确");
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            if (msg != "")
            {
                ModelState.AddModelError("", msg);
            }
            
            return View();
        }

        [HttpPost]
        public JsonResult Logout()
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                //取消Session会话
                Session.Abandon();
                //删除Forms验证票证
                FormsAuthentication.SignOut();

                ret.Status = "success";
                return Json(ret);
            }
            catch(Exception ex)
            {
                 throw ex;
            }
        }
    }
}
