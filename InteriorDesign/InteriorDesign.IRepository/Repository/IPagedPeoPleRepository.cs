using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteriorDesign.Model;
using InteriorDesign.Context;

namespace InteriorDesign.IRepository
{
    /// <summary>
    /// PagedPeoPle数据库操作接口定义
    /// </summary>
    public interface IPagedPeoPleRepository : IBaseRepository<PagedPeoPle, InteriorDesignContext>
    {

    }
}
