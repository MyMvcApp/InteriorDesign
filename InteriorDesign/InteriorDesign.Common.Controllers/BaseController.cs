﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using InteriorDesign.Model.End;
using InteriorDesign.Model.Front;
using InteriorDesign.Helper;

namespace InteriorDesign.Common.Controllers
{
    //在这个基类中存储一些公用的东西
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前后台的登录用户信息
        /// </summary>
        public AdminUser CurrentEndUser
        {
            get
            {
                if (HttpContext.Session == null || HttpContext.Session["currentEndAdmin"] == null)
                    return new AdminUser();
                return (AdminUser)HttpContext.Session["currentEndAdmin"];
            }
            set
            {
                HttpContext.Session["currentEndAdmin"] = value;
            }
        }

        public new HttpContextBase HttpContext
        {
            get
            {
                HttpContextWrapper context = new HttpContextWrapper(System.Web.HttpContext.Current);
                return (HttpContextBase)context;
            }
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        /// <summary>
        /// 校验错误信息
        /// </summary>
        /// <returns></returns>
        public ResponseResult Validate()
        {
            string message = string.Empty;
            if (ModelState.Values.Count > 0)
            {
                foreach (var val in ModelState.Values)
                {
                    if (val.Errors.Count > 0)
                    {
                        foreach (var msg in val.Errors)
                        {
                            message += msg.ErrorMessage + "<br/>";
                        }
                    }
                }
            }
            return new ResponseResult() { Status =ResponseStatus.validateError.ToString(), Message = message };
        }

        /// <summary>
        /// 判断是否登录消息
        /// </summary>
        /// <returns></returns>
        public ResponseResult CheckIfLoginMessage() 
        {
            if (!CheckIfLogin())
            {
                return new ResponseResult() { Status = ResponseStatus.loginError.ToString(), Message = ResponseMessage.回话已过期请重新登录.ToString() };
            }
            return null;
        }

        /// <summary>
        /// 判断是否登录状态
        /// </summary>
        /// <returns></returns>
        public bool CheckIfLogin() 
        {
            if (CurrentEndUser.ID == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断登录Grid用
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResult ResponseForGrid(string message) 
        {
          return  new JsonResult() { Data = new { total = 0, rows =new List<object>(), Status = ResponseStatus.commonError.ToString(),Message = message }};
        }

    }
}
