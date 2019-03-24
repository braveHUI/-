using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ViewModels;


namespace BraveMvc.Controllers
{
    public class HistoryBookController : Controller
    {
        // GET: HistoryBook
        public ActionResult Index()
        {
            var data = HistoryBookManage.FindAllBook().OrderBy(p => p.Book_id);        
            ViewModels.historybk index = new ViewModels.historybk();
            index.FindAllBook = data;          
            return View(index);
        }
        public ActionResult ClassIndex(int classid)
        {           
            var findclass = HistoryBookManage.FindClassBook(classid);
            ViewModels.historybk index = new ViewModels.historybk();
            index.FindClassBook = findclass;
             return View(index);
        }
      

    }
}