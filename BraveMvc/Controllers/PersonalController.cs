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
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index(int id)
        {
            var users = PersonalManage.FinduserId(id);
            var goodss = GoodsManage.FindAllBooks().OrderByDescending(p => p.Grounding).Take(6);
            var cart = PersonalManage.findcart(id).OrderByDescending(p=>p.Addtime).Take(2);
            ViewModels.Personal index = new ViewModels.Personal()
            {
                userde = users,
              Good1 = goodss,
              cart1=cart
            };
            HttpContext.Session["User_id"] = id;
            ViewBag.cartcount = PersonalManage.findcarticount(id);
            return View(index);
        }
        [HttpGet]
        public ActionResult Penson()
        {
            return View();
        }
        public ActionResult xiaoxi()
        {
            return View();
        }
    }
}