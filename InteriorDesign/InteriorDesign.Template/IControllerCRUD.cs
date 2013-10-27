using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using InteriorDesign.IRepository;
using InteriorDesign.Model;
using System.Data;
using System.Data.Entity;
using System.Web;

namespace InteriorDesign.Template
{
    public interface IControllerCRUD<TEntity, TContext>
        where TEntity : BaseModel
        where TContext : DbContext
    {
        /// <summary>
        /// 页面基类的访问数据库仓库
        /// </summary>
        IBaseRepository<TEntity, TContext> BaseReposity { get; set; }

        /// <summary>
        /// 页面新增和更新方法
        /// </summary>
        /// <param name="T">当前操作实体</param>
        /// <returns></returns>
        [HttpPost]
        JsonResult CreateOrUpdate(TEntity T);
        /// <summary>
        /// 页面新增方法
        /// </summary>
        /// <param name="T">当前操作实体</param>
        /// <returns></returns>
        [HttpPost]
        JsonResult Create(TEntity T);

        /// <summary>
        /// 页面更新方法
        /// </summary>
        /// <param name="T">当前操作实体</param>
        /// <returns></returns>
        [HttpPost]
        JsonResult Update(TEntity T);

        /// <summary>
        /// 页面删除方法
        /// </summary>
        /// <param name="T">当前操作实体</param>
        /// <returns></returns>
        [HttpPost]
        JsonResult Delete(TEntity T);

        /// <summary>
        /// 支持EasyUI的查询方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpPost]
        JsonResult GetDataList(string page, string rows);

        /// <summary>
        /// 通过id作为查询条件的查询方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        JsonResult GetDataListByID(string page, string rows, string id);
    }
}
