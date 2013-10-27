using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteriorDesign.Model.Front;
using InteriorDesign.Context;

namespace InteriorDesign.IRepository.Front
{
    /// <summary>
    /// PagedPeoPle数据库操作接口定义
    /// </summary>
    public interface IPagedPeoPleRepository : IBaseRepository<PagedPeoPle, InteriorDesignContext>
    {

    }
}
