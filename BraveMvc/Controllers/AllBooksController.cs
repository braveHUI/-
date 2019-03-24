using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BLL;
using Models;

namespace BraveMvc.Controllers
{
    public class AllBooksController : Controller
    {
        BraveEntities db = new BraveEntities();
        // GET: AllBooks
        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var bookpage = db.HistoryBook.OrderBy(p => p.Book_id).ToPagedList(pageNum,pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("Index", bookpage);
            }
            else
            {
                return View("Index",bookpage);
            }      
        }
    }
}