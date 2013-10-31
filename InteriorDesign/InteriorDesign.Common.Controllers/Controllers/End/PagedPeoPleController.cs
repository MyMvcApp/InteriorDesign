using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using InteriorDesign.Model.Front;
using InteriorDesign.Repository.Front;
using InteriorDesign.Context;
using InteriorDesign.Template;
using System.Linq.Expressions;
using PagedList;
using InteriorDesign.Helper;
using InteriorDesign.IRepository.Front;
using InteriorDesign.Common.Controllers;
namespace InteriorDesign.Controllers.Common.Controllers.End
{
    //PagedPeoPle对应的后台控制器
    public class PagedPeoPleController : BaseCRUDController<PagedPeoPle, InteriorDesignContext>
    {
        private IPagedPeoPleRepository pagedPeoPleRepository;
        public PagedPeoPleController()
        {
            pagedPeoPleRepository = new PagedPeoPleRepository(new InteriorDesignContext());
            BaseReposity = pagedPeoPleRepository;
        }

        [HttpGet]
        public ActionResult PagedPeopleEnd()
        {
            return View();
        }
    }
}
