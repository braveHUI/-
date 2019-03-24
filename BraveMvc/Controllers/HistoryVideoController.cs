using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ViewModels;
using Models;

namespace BraveMvc.Controllers
{
    public class HistoryVideoController : Controller
    {
        // GET: HistoryVideo
        public ActionResult Index()
        {
            var findall = HistoryVideoManage.FindAllVideo().OrderByDescending(p => p.Video_id).Take(8);
            ViewModels.historyvd index = new ViewModels.historyvd();
            index.FindAllVideo = findall;
            return View(index);
        }
        public ActionResult Detail(int id, int classid)
        {
            var findvideo = HistoryVideoManage.FindVideo(id);
            var findsame = HistoryVideoManage.FindSameVideo(classid).Take(3);
            ViewModels.historyvd index = new ViewModels.historyvd();
            index.FindVideo = findvideo;
            index.FindSameVideo = findsame;
            return View(index);
        }
        public ActionResult Search(string search_internal_input)
        {
                    
            if (!String.IsNullOrEmpty(search_internal_input))
            {
                var findvd = HistoryVideoManage.SearchVideo(search_internal_input);
                return PartialView("Search", findvd);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Classify(int classid)
        {
            var findclass = HistoryVideoManage.FindSameVideo(classid);
            ViewModels.historyvd index = new ViewModels.historyvd();
            index.FindSameVideo = findclass;
            return View(index);

        }
    }
  
}