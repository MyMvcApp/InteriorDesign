using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using InteriorDesign.Context;
using InteriorDesign.Helper;
using InteriorDesign.Model.End;
using InteriorDesign.Repository.End;
using InteriorDesign.Common.Controllers;
using InteriorDesign.IRepository.End;
using System.Data.Entity.Infrastructure;
namespace InteriorDesign.Commom.Controllers.Controllers.End.Common
{
    public class AdminUserController :BaseCRUDController <AdminUser, InteriorDesignContext>
    {
        private IAdminUserRepository adminUserRepository;
        public AdminUserController()
        {
            adminUserRepository = new AdminUserRepository(new InteriorDesignContext());
            BaseReposity = adminUserRepository;
        }

        [HttpGet]
        public ActionResult UserManage()
        {
            return View();
        }

        [HttpPost]
        public override JsonResult CreateOrUpdate(AdminUser user)
        {
            if (user.ID > 0) 
            {
                user.AdminPwd = WebHelper.GetMD5Hash("123");// 新增用户默认密码为123
            }
            return base.CreateOrUpdate(user);
        }

        [HttpPost]
        public JsonResult UpdatePwd(UpdatePwdParm parm)
        {
            try
            {
                ResponseResult ret = new ResponseResult();

                if(CheckIfLogin())
                {
                    string adminName = CurrentEndUser.AdminName;
                    string pwd = WebHelper.GetMD5Hash(parm.AdminPwd);

                    Expression<Func<AdminUser, bool>> filter = null;
                    if (!String.IsNullOrWhiteSpace(adminName))
                        filter = d => d.AdminName.ToUpper().Equals(adminName.ToUpper())
                            && d.AdminPwd.ToUpper().Equals(pwd);

                    IEnumerable<AdminUser> data = adminUserRepository.GetData(filter: filter);
                    if (data !=  null && data.Count() > 0)
                    {
                        AdminUser user = data.FirstOrDefault();
                        user.AdminPwd = WebHelper.GetMD5Hash(parm.AdminNewPwd);
                        adminUserRepository.Update(user);
                        ret.Status = ResponseStatus.success.ToString();
                    }
                    else
                    {
                        ret.Status = ResponseStatus.commonError.ToString();
                        ret.Message = "原始密码不正确";
                    }
                }

                return Json(ret);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
