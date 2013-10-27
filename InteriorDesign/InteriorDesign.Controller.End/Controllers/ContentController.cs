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
using InteriorDesign.Controllers.Common;
using InteriorDesign.IRepository.End;
using System.Data.Entity.Infrastructure;
namespace InteriorDesign.Controllers.End.Controllers
{
    public class ContentController : BaseCRUDController<AdminUser, InteriorDesignContext>
    {
        private IAdminUserRepository adminUserRepository;
        public ContentController()
        {
            adminUserRepository = new AdminUserRepository(new InteriorDesignContext());
            BaseReposity = adminUserRepository;
        }

        public ActionResult UserManage()
        {
            return View();
        }

        [HttpPost]
        public override JsonResult CreateOrUpdate(AdminUser user)
        {
            ResponseResult ret = new ResponseResult();
            try
            {
                if (user.ID != 0)
                {
                    // TODO:修改处理
                    adminUserRepository.Update(user);
                }
                else
                {
                    // TODO:添加处理
                    user.AdminPwd = WebHelper.GetMD5Hash("123");// 新增用户默认密码
                    adminUserRepository.Create(user);
                }

                ret.Status = ResponseStatus.success.ToString();
                ret.Message = ResponseMessage.操作成功.ToString();
                return Json(ret);
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateConcurrencyException)
                {
                    ret.Status = ResponseStatus.rowVersionError.ToString();
                    ret.Message = ResponseMessage.数据已修改请刷新后重试.ToString();
                }
                else
                {
                    if (ex.Message.IndexOf("Value cannot be null.") > -1)
                    {
                        ret.Status = ResponseStatus.rowVersionError.ToString();
                        ret.Message = ResponseMessage.数据已修改请刷新后重试.ToString();
                    }
                    else
                    {
                        ret.Status = ResponseStatus.commonError.ToString();
#if DEBUG
                        ret.Message = ex.Message;
#else 
                            ret.Message = ResponseMessage.操作失败.ToString();
#endif
                    }
                }
                return Json(ret);
            }
        }

        [HttpPost]
        public JsonResult UpdatePwd(UpdatePwdParm parm)
        {
            try
            {
                ResponseResult ret = new ResponseResult();

                if (Session["admin"] != null)
                {
                    string adminName = Session["admin"].ToString();
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
