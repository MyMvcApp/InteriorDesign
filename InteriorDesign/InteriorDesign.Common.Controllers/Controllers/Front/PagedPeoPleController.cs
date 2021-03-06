﻿using System;
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
namespace InteriorDesign.Controllers.Common.Controllers.Front
{
    //PagedPeoPle对应的前台控制器
    public class PagedPeoPleController : BaseController
    {
        private IPagedPeoPleRepository pagedPeoPleRepository;
        public PagedPeoPleController()
        {
            pagedPeoPleRepository = new PagedPeoPleRepository(new InteriorDesignContext());
        }

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, int pageSize = 1)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.AgeSortParm = String.IsNullOrEmpty(sortOrder) ? "Age desc" : "";
            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;
            Func<IQueryable<PagedPeoPle>, IOrderedQueryable<PagedPeoPle>> orderBy = null;
            switch (sortOrder)
            {
                case "Age desc":
                    orderBy = new Func<IQueryable<PagedPeoPle>, IOrderedQueryable<PagedPeoPle>>(q => q.OrderByDescending(s => s.Age));
                    break;
                default:
                    orderBy = new Func<IQueryable<PagedPeoPle>, IOrderedQueryable<PagedPeoPle>>(q => q.OrderBy(s => s.Age));
                    break;
            }
            int pageNumber = (page ?? 1);
            Expression<Func<PagedPeoPle, bool>> filter = null;
            if (!String.IsNullOrWhiteSpace(searchString))
                filter = d => d.Name.ToUpper().Contains(searchString.ToUpper());
            IPagedList<PagedPeoPle> PagedPeoPles = pagedPeoPleRepository.GetPagedData(
              filter: filter,
              orderBy: orderBy,
              pageSize: pageSize,
              pageNumber: pageNumber);
            return View(PagedPeoPles);
        }

        //
        // GET: /PagedPeoPle/Details/5

        public ActionResult Details(int id = 0)
        {
            PagedPeoPle pagedPeoPle = pagedPeoPleRepository.GetByID(id);
            if (pagedPeoPle == null)
            {
                return HttpNotFound();
            }
            return View(pagedPeoPle);
        }

        //
        // GET: /PagedPeoPle/Create

        public ActionResult Create()
        {
            return View();
        }
        //
        // GET: /PagedPeoPle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PagedPeoPle pagedPeoPle = pagedPeoPleRepository.GetByID(id);
            if (pagedPeoPle == null)
            {
                return HttpNotFound();
            }
            return View(pagedPeoPle);
        }

        //
        // POST: /PagedPeoPle/Edit/5

        [HttpPost]
        public ActionResult Edit(PagedPeoPle pagedPeoPle)
        {
            if (ModelState.IsValid)
            {
                pagedPeoPleRepository.Update(pagedPeoPle);
                return RedirectToAction("Index");
            }
            return View(pagedPeoPle);
        }


        public ActionResult CreatePeople(PagedPeoPle pagedPeoPle) 
        {
            if (ModelState.IsValid)
            {
                pagedPeoPleRepository.Create(pagedPeoPle);
                return RedirectToAction("Index");
            }

            return View(pagedPeoPle);
        }

        //
        // GET: /PagedPeoPle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PagedPeoPle pagedPeoPle = pagedPeoPleRepository.GetByID(id);
            if (pagedPeoPle == null)
            {
                return HttpNotFound();
            }
            return View(pagedPeoPle);
        }

        protected override void Dispose(bool disposing)
        {
            pagedPeoPleRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
