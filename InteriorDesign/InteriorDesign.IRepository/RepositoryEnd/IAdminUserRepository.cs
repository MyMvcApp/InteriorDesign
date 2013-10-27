using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InteriorDesign.Model;
using InteriorDesign.Context;

namespace InteriorDesign.IRepository
{
    /// <summary>
    /// AdminUser数据库操作接口定义
    /// </summary>
    public interface IAdminUserRepository : IBaseRepository<AdminUser, InteriorDesignContext>
    {

    }
}
