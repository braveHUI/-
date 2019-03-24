using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using BLL;
using System.Net;
using Models;
using DAL;
using IDAL;
using DALFactory;
using ViewModels;
using System.Data.Entity.Validation;



namespace BraveMvc.Controllers
{
  
    public class MallsController : Controller
    {
        // GET: Malls
       
        public ActionResult Index()
        {
            var good=GoodsManage.FindAllBooks().OrderByDescending(p => p.Grounding).Take(8);
            var Zhanji = GoodsManage.FindAllBooks().Where(b => b.Classify_id == 1).Take(6);
            var Qiang = GoodsManage.FindAllBooks().Where(c => c.Classify_id == 4).Take(6);
            var Hangmu = GoodsManage.FindAllBooks().Where(a => a.Classify_id == 3).Take(6);
            var Feixing = GoodsManage.FindAllBooks().Where(d => d.Classify_id == 2).Take(6);
            var Tanke = GoodsManage.FindAllBooks().Where(e => e.Classify_id == 8).Take(6);
         
            ViewModels.Goodss index = new ViewModels.Goodss();
            index.Good6 = good;
            index.Good1 = Zhanji;
            index.Good2 = Qiang;
            index.Good3 = Hangmu;
            index.Good4 = Feixing;
            index.Good5 = Tanke; 


            return View(index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult aboutss()
        {
            return View();
        }
      
        public ActionResult Classify()
        {
            var clas = ClassifyManage.FindAllClassify();
           
            ViewModels.Clasaifymenu clmenu = new ViewModels.Clasaifymenu();
            
          
           
            clmenu.Classify1 = clas;
            return View("Classify", clmenu);
        }
        //详情
        public ActionResult Detail(int id,int classid)
        {

            var good = GoodsManage.Getgood(id);
            var classif = GoodsManage.FindAllBooks().Where(p => p.Classify_id == classid);
            var Comment = CommentGoodsManage.findallcomment(id);
            var userid = Convert.ToInt32(Session["User_id"]);
            ViewModels.GoodsDetail index = new GoodsDetail();
            if (userid > 0)
            {
                var carts = CartManage.Findusercart(userid);

                index.Carts1 = carts;
            }
            if (good == null)
            {
                return HttpNotFound();
            }
            if (classif == null)
            {
                return HttpNotFound();
            }
            if (Comment == null)
            {
                return HttpNotFound();
            }
           
            index.Goodss = good;
            index.Goods11 = classif;
            index.Comment1 = Comment;
          
            return View(index);
            //return View();
        }
        [HttpPost]
        public ActionResult addComment(CommentGoods comgoods)
        {
            string content = Request["detail-goods-comment"];
            int goodsid = int.Parse(Request["detail-goodsName"].ToString());
            int userid = int.Parse(Session["User_id"].ToString());
            if (content == null||content.Length==0)
            {
                return Content("<script>;alert('评论内容不能为空!');history.go(-1)</script>");
            }
            else if (ModelState.IsValid)
              {
                    comgoods.User_id = userid;
                    comgoods.Goods_id = goodsid;
                    comgoods.Content = content;
                    comgoods.CommentTime = DateTime.Now;
                    CommentGoodsManage.AddCommentGoods(comgoods);
                    return Content("<script>;alert('评论成功!');history.go(-1)</script>");
               }
           
          
            return RedirectToAction("Detail", "Malls");


        }
        public ActionResult Reply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reply(ReplyGoods repgoods)
        {
            string reply = Request["replaygoods"];
            int commid = Convert.ToInt32(Request["commendid"]);
            int userid = Convert.ToInt32(Session["User_id"]);
            var replylist = CommentGoodsManage.findallreply(commid);
            if (reply == null)
            {
                return Content("<script>;alert('回复内容不能为空!');history.go(-1)</script>");
            }
            else if (ModelState.IsValid)
            {
                repgoods.CommentGoods_id = commid;
                repgoods.User_id = userid;
                repgoods.Content = reply;
                repgoods.ReplyTime = DateTime.Now;
                CommentGoodsManage.addReplyGoods(repgoods);
                return Content("<script>;alert('回复成功!');history.go(-1)</script>");
            }
                return RedirectToAction("Detail", "Malls");
        }
      
        public ActionResult SelectReply(int commendid)
        {
            var replydf = CommentGoodsManage.findallreply(commendid);
            ViewModels.GoodsDetail der = new GoodsDetail();
            der.Reply1 = replydf;
            return View(der);
        }


        public ActionResult selectGood(string searchString,string SortInfoFrom)
        {
            var good = GoodsManage.selectGoods();
            var tugood = GoodsManage.FindGoods().Take(3);
            if (!String.IsNullOrEmpty(searchString))
            {
                good = good.Where(s => s.GoodsDes.Contains(searchString)||s.GoodsName.Contains(searchString)||s.Classify.ClassifyName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(SortInfoFrom))
            {
                if (SortInfoFrom == "价格降序")
                {
                    good = good.OrderByDescending(p => p.GoodsPrice);
                }
                else if (SortInfoFrom == "价格升序")
                {
                    good = good.OrderBy(p => p.GoodsPrice);
                }

                else if (SortInfoFrom == "更新时间")
                {
                    good = good.OrderByDescending(p => p.Grounding);
                }

            }
                SelectGoods inde = new SelectGoods();
            inde.good1 = good;
            inde.good2 = tugood;
            return View(inde);
        }
        public String AddOrder(Order order,int goodid,int num ,decimal price)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            order.Good_id = goodid;
            order.Price = price;
            order.Amount = num;
            order.TotalMoney = num * price;
            order.User_id = userid;
            order.Site_id = 2;
            CartManage.AddOrder(order);
            return "ok";


        }
    }
}