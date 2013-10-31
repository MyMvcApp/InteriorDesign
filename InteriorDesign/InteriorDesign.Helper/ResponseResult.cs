using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesign.Helper
{
    /// <summary>
    /// 项目操作返回结果
    /// </summary>
    public class ResponseResult
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public enum ResponseStatus { 
        success,
        commonError,
        rowVersionError,
        loginError,
        validateError
    }

    public enum ResponseMessage { 
        操作成功,
        操作失败,
        数据已修改请刷新后重试,
        回话已过期请重新登录
    }
}
