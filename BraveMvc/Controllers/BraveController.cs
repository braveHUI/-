using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;
using IDAL;
using DALFactory;


namespace BraveMvc.Controllers
{
    public class BraveController : Controller
    {
        // GET: Brave
        public ActionResult Index()
        {
            var news = BraveManage.FindAllNews().OrderByDescending(p => p.SubmtDate).Take(4);
            var video = BraveManage.FindAllvideo().OrderByDescending(p => p.MilitaryVideoTime).Take(4);
            var video1 = BraveManage.FindAllvideo1().OrderByDescending(p => p.VideoTime).Take(3);
            var history1 = BraveManage.FindAllhistory().OrderByDescending(p => p.HistoryTime).Take(10);
            var goodss = GoodsManage.FindAllBooks().OrderByDescending(p => p.Grounding).Take(3);
            var spots = BraveManage.FindAllSpots().OrderByDescending(p => p.RedSpotsName).Take(3);
            var share = BraveManage.FindAllShare().OrderByDescending(p => p.RedShareTime).Take(4);
            ViewModels.Brave index = new ViewModels.Brave();
            index.new1 = news;
            index.Video = video;
            index.Video1 = video1;
            index.history = history1;
            index.Good1 = goodss;
            index.spots1 = spots;
            index.Share = share;
            return View(index);
        }
    }
}