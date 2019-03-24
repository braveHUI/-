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
using ViewModels;
using PagedList;
using System.Net;

namespace BraveMvc.Controllers
{
    public class RedSpotsController : Controller
    {

        BraveEntities db = new BraveEntities();
        // GET: RedSpots
        public ActionResult Index()
        {
            var section = BraveManage.FindAllSection();
            var redsopt = BraveManage.FindAllSpots();
            
            ViewModels.Brave index = new ViewModels.Brave();
            index.spots1 = redsopt;
            index.RedSection1 = section;
            return View(index);
        }
        public ActionResult Report()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Redid(int? page, int ?sectionid,string search)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var redsopt = BraveManage.FindAllSpots();
            if (!String.IsNullOrEmpty(search))
            {
                redsopt = redsopt.Where(a => a.RedSpotsName.Contains(search) || a.RedArea.Contains(search)||a.Location.Contains(search));
            }
            if (sectionid >=1)
            {
                redsopt = redsopt.Where(a => a.RedSection_id == sectionid);
            }
           
                
                ViewBag.id = sectionid;
                if (Request.IsAjaxRequest())

                {
                    return PartialView("Redid", redsopt.OrderBy(a => a.RedSpots_id).ToPagedList(pageNum, pageSize));
                }
                else {
                    return View("Redid", redsopt.OrderBy(a => a.RedSpots_id).ToPagedList(pageNum, pageSize));
                }
      
           

         


        }
        public ActionResult ShareDetails(int id)
        {

            var redsharede1= BraveManage.FindSharede(id);
          
            var gengduored = BraveManage.FindAllSpots().OrderByDescending(p => p.RedSpots_id).Take(10);
            ViewBag.name11 = redsharede1.RedSpots.RedSpotsName;
            ViewBag.redid = redsharede1.RedSpots_id;
            ViewModels.Brave index = new ViewModels.Brave()
            {
                 spots1=gengduored,
           redsharede=redsharede1,


            };
            return View(index);
        }
    
        public ActionResult Details(int id)
        {

            var redde = BraveManage.FindRedId(id);
            var redshare = BraveManage.FindShareid(id);
            var gengduored = BraveManage.FindAllSpots().OrderByDescending(p => p.RedSpots_id).Take(10);
            var comred = CommentRedSpotsManage.FindRedCom(id);
            if (redde == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewModels.Brave index = new ViewModels.Brave()
            { 

                spots1 = gengduored,
                redshare1 = redshare,
                redde1 = redde,
                Commred1=comred,


            };
            ViewBag.count1 = BraveManage.findcoment(id);
            return View(index);
        }
     
      

        public ActionResult Create(int ?id)
        {
            ViewBag.spotid = id;
            return View();
        }

        // POST: RedSpotsAdds/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
    
        public ActionResult Create( RedShare redShare,int id)
        {
            HttpPostedFileBase postimage1 = Request.Files["Image1"];
            


            try
            {



                if (postimage1 != null)
                {
                    string filePath = postimage1.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\img\RedShare\") + filename;
                    string relativepath = @"/img/RedShare/" + filename;
                    postimage1.SaveAs(serverpath);
                    redShare.RedShareImage = relativepath;
                }

                else
                {
                    return Content("<script>;alert('请先上传图！');history.go(-1)</script>");

                }


                if (ModelState.IsValid)
               {
               redShare.User_id =1;
                redShare.RedSpots_id= id;
                redShare.RedShareTime = DateTime.Now;
                db.RedShare.Add(redShare);
                db.SaveChanges();
                    return Content("<script>;alert('发布成功！');history.go(-1)</script>");
                    //return RedirectToAction("Index");
                }
                else
                {
                    return Content("<script>;alert('发布失败！');history.go(-1)</script>");
                }

                return View(redShare);



            }

            catch (Exception ex)
            {
                return Content(ex.Message);
            }


           
        }

        [HttpPost]
      
        public String addComment(CommentRedSpots comredspots,string essaycontent,int forumid)
        {
            
            int userid = int.Parse(Session["User_id"].ToString());
            if (essaycontent != null || essaycontent.Length!= 0)
            {
                comredspots.User_id = userid;
                comredspots.RedSpots_id = forumid;
                comredspots.Content = essaycontent;
                comredspots.CommentTime = DateTime.Now;
                CommentRedSpotsManage.AddCommentRedSpots(comredspots);
                return "cg";
            }

            else {
                return "cc";
             }
            //if (content == null || content.Length == 0)
            //{
            //    return Content("<script>;alert('评论内容不能为空!');history.go(-1)</script>");
            //}
            //else if (ModelState.IsValid)
            //{
            //    comredspots.User_id = userid;
            //    comredspots.RedSpots_id = redspotsid;
            //    comredspots.Content = content;
            //    comredspots.CommentTime = DateTime.Now;
            //    CommentRedSpotsManage.AddCommentRedSpots(comredspots);
            //    return Content("<script>;alert('评论成功!');history.go(-1)</script>");

                //}



                //return RedirectToAction("Details", "RedSpots");


        }
        public ActionResult Reply()
        {
            return View();
        }
        [HttpPost]
        public String Reply(ReplyRedSpots repredspots, string essaycontent, int forumid)
        {
           
            int userid = Convert.ToInt32(Session["User_id"]);
            //var replylist = CommentRedSpotsManage.FindRedRep(commid);
            if (essaycontent !=null)
            //{
            //    return Content("<script>;alert('回复内容不能为空!');history.go(-1)</script>");
            //}
            //else

            {
                repredspots.CommentRedSpots_id = forumid;
                repredspots.User_id = userid;
                repredspots.Content = essaycontent;
                repredspots.ReplyTime = DateTime.Now;
                CommentRedSpotsManage.addReplyRedSpots(repredspots);
                return "cg";
            }

            else {
                return "cc";
            }
        }

            //ViewModels.Brave index = new ViewModels.Brave();

            //index.Repred1 = replylist;

            //return View(index);
        

        [HttpGet]
        public ActionResult SelectReply(int id)
        {
            var repred = CommentRedSpotsManage.FindRedRep(id);
           
            ViewModels.Brave der = new Brave();
            der.Repred1 = repred;
            return View(der);
        }



    }
}