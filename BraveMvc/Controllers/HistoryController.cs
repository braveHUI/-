using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using ViewModels;

namespace BraveMvc.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        //public ActionResult Index()
        //{
        //    var findbook = HistoryBookManage.FindAllBook().OrderByDescending(p => p.Book_id).Take(6);
        //    var data = HistoryManage.FindHistory().OrderByDescending(p => p.History_id);
        //    var findvideo = HistoryVideoManage.FindAllVideo().OrderByDescending(p => p.Video_id);
        //    ViewModels.Historys index = new ViewModels.Historys();
        //    index.FindHistory = data;
        //    index.FindAllVideo = findvideo;
        //    index.FindAllBook = findbook;
        //    return View(index);
        //}
        public ActionResult ALLIndex()
        {
            var findbook = HistoryBookManage.FindAllBook().OrderByDescending(p => p.Book_id).Take(6);
            var data = HistoryManage.FindHistory().OrderByDescending(p => p.History_id);
            var findvideo = HistoryVideoManage.FindAllVideo().OrderByDescending(p => p.Video_id);
            ViewModels.Historys index = new ViewModels.Historys();
            index.FindHistory = data;
            index.FindAllVideo = findvideo;
            index.FindAllBook = findbook;
            return View(index);
        }
        public ActionResult HistoryIndex()
        {
            var findall = HistoryManage.FindHistory();
            ViewModels.Historys index = new ViewModels.Historys();
            index.FindHistory = findall;
            return View(index);
        }      
        public ActionResult HistoryDetail(int id,int classid)
        {
            var detail = HistoryManage.HistoryDetail(id);
            var classvd = HistoryManage.FindClassHistory(classid).Take(5);
            ViewModels.Historys index = new ViewModels.Historys();
            index.HistoryDetail = detail;
            index.FindClassHistory = classvd;
            return View(index);
        }
        public ActionResult FindClassHistory(int classid)
        {
            var findclassname = HistoryManage.FindClassHistory(classid).Take(1);
            var findclass = HistoryManage.FindClassHistory(classid);
            ViewModels.Historys index = new ViewModels.Historys();
            index.FindClassHistory = findclass;
            index.FindClassName = findclassname;
            return View(index);
        }

}
}