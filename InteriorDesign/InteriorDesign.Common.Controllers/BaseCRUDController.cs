using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using InteriorDesign.Model;
using InteriorDesign.Helper;
using InteriorDesign.Template;
using InteriorDesign.IRepository;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace InteriorDesign.Common.Controllers
{
     public class BaseCRUDController<TEntity, TContext> : BaseController, IControllerCRUD<TEntity, TContext>
        where TEntity : BaseModel
        where TContext : DbContext
    {
        public IBaseRepository<TEntity, TContext> BaseReposity { get; set; }

         /// <summary>
         /// 新增和更新方法
         /// </summary>
         /// <param name="T"></param>
         /// <returns></returns>
        [HttpPost]
        public virtual JsonResult CreateOrUpdate(TEntity T)
        {
            if (base.CheckIfLoginMessage() != null) return Json(base.CheckIfLoginMessage());
            if (!ModelState.IsValid) return Json(Validate());
            ResponseResult ret = new ResponseResult();
            try
            {
                if (T.ID != 0)
                {
                    BaseReposity.Update(T);
                }
                else
                {
                    BaseReposity.Create(T);
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
         /// <summary>
         /// 新增方法
         /// </summary>
         /// <param name="T"></param>
         /// <returns></returns>
        [HttpPost]
        public virtual JsonResult Create(TEntity T)
        {
            if (base.CheckIfLoginMessage() != null) return Json(base.CheckIfLoginMessage());
            if (!ModelState.IsValid) return Json(Validate());
            ResponseResult ret = new ResponseResult();
            try
            {
                BaseReposity.Create(T);
                ret.Status = "success";
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

         /// <summary>
         /// 更新方法
         /// </summary>
         /// <param name="T"></param>
         /// <returns></returns>
        [HttpPost]
        public virtual JsonResult Update(TEntity T)
        {
            if (base.CheckIfLoginMessage() != null) return Json(base.CheckIfLoginMessage());
            if (!ModelState.IsValid) return Json(Validate());
            ResponseResult ret = new ResponseResult();
            try
            {
                BaseReposity.Create(T);
                ret.Status = "success";
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

         /// <summary>
         /// 删除方法
         /// </summary>
         /// <param name="T"></param>
         /// <returns></returns>
        [HttpPost]
        public virtual JsonResult Delete(TEntity T)
        {
            if (base.CheckIfLoginMessage() != null) return Json(base.CheckIfLoginMessage());
            ResponseResult ret = new ResponseResult();
            try
            {
                BaseReposity.Delete(T.ID);
                ret.Status = "success";
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

         /// <summary>
         /// 支持EasyUI的分页查询方法
         /// </summary>
         /// <param name="page"></param>
         /// <param name="rows"></param>
         /// <returns></returns>
        [HttpPost]
        public virtual JsonResult GetDataList(string page, string rows)
        {
            if (base.CheckIfLoginMessage() != null) return Json(base.CheckIfLoginMessage());
            try
            {
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby
                       = new Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>(q => q.OrderBy(s => s.ID));
                return BaseReposity.GetPagedJsonData(orderBy: orderby, pageSize: Convert.ToInt32(rows), pageNumber: Convert.ToInt32(page));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult { Status = ResponseStatus.commonError.ToString(), Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

         /// <summary>
        /// 支持EasyUI的分页查询方法
         /// </summary>
         /// <param name="page"></param>
         /// <param name="rows"></param>
         /// <param name="id">一个id为过滤条件,可以在子类中进行重写过滤条件</param>
         /// <returns></returns>
        [HttpPost]
        public virtual JsonResult GetDataListByID(string page, string rows, string id)
        {
            if (base.CheckIfLoginMessage() != null) return Json(base.CheckIfLoginMessage());
            try
            {
                Expression<Func<TEntity, bool>> filter = null;
                if (!string.IsNullOrWhiteSpace(id) && id != "null")
                {
                    filter = d => d.ID.Equals(Convert.ToInt32(id));
                }
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby
                       = new Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>(q => q.OrderBy(s => s.ID));
                return BaseReposity.GetPagedJsonData(filter: filter, orderBy: orderby, pageSize: Convert.ToInt32(rows), pageNumber: Convert.ToInt32(page));
            }
            catch (Exception ex)
            {
                return Json(new ResponseResult { Status = ResponseStatus.commonError.ToString(), Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
