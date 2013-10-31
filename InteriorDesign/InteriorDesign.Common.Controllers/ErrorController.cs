using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace InteriorDesign.Common.Controllers
{
    /// <summary>
    /// 用于错误处理的控制器
    /// </summary>
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            return View("NotFound");
        }
    }
}
