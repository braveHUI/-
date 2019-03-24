using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using BLL;
using Models;

namespace BraveMvc.Controllers
{
    public class EssayController : Controller
    {
        // GET: Essay
        public ActionResult Index()
        {
            var sess = ForumManage.selectsec().Take(6);
            ViewBag.ForumSession_id = new SelectList(sess, "ForumSection_id", "ForumSectionName");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddEssay([Bind(Include = "Forum_id,ForumName,ForumContent,ForumTime,User_id,ForumSection_id,ForumImage,ForumClicks,ForumDec")] Forum forum, HttpPostedFileBase file)
        {
            try
            {

                string essayname = Request["forum_nume"];
                string essaydec = Request["forum_dec"];
                int sessssw =Convert.ToInt32(Request["ForumSession_id"]);
               
                if(file != null)
                {
                    string filePath = file.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\essay\") + filename;
                    string relativepath = @"/Images/essay/" + filename;
                    file.SaveAs(serverpath);
                    forum.ForumImage = relativepath;
                }
                else
                {
                    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");

                }
                if (ModelState.IsValid)
                {
                    forum.ForumSection_id = sessssw;
                    forum.ForumName = essayname;
                    forum.ForumDec = essaydec;
                    forum.ForumTime = DateTime.Now;
                    forum.User_id = Convert.ToInt32(Session["User_id"]);
                    forum.ForumClicks = 0;
                    ForumManage.AddToforum(forum);

                   
                }
                var sess = ForumManage.selectsec().Take(6);
                ViewBag.ForumSession_id = new SelectList(sess, "ForumSection_id", "ForumSectionName",forum.ForumSection_id);
                return Content("<script>;alert('发表成功！');window.location.href='/Forum/ClassifyEssay'</script>");

            }
            catch (DbEntityValidationException ex)
            {
                return Content(ex.Message);
            }
           
        }

        public ActionResult Post(int id)
        {
            HttpContext.Session["Forution_id"] = id;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost([Bind(Include = "Post_id,User_id,PostContent,PostTime,ForumSection_id,Post_Click,PostName")]Post post)
        {
            try
            {
                string postname = Request["post_nume"];
                var forumid = Convert.ToInt32(Session["Forution_id"]);
                var fghht = Session["Forution_id"].ToString();

                if (ModelState.IsValid)
                {
                    post.ForumSection_id = forumid;
                    post.PostName = postname;
                    post.PostTime = DateTime.Now;
                    post.Post_Click = 1;
                    post.User_id = Convert.ToInt32(Session["User_id"]);
                   
                    PostManage.AddTopost(post);
                }
             
                var sdeadw = Session["Forution_id"].ToString();
                return Content("<script>;alert('发表成功！');history.go(-2)</script>");
            }
            catch (DbEntityValidationException ex)
            {
                return Content(ex.Message);
            }
           
          
        }
       
        public ActionResult AddForumsection()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddJunba(ForumSection forumssde, HttpPostedFileBase file)
        {
            try
            {
                var forummi = Request["post_nume"];
                var userid = Convert.ToInt32(Session["User_id"]);

                if (file != null)
                {
                    var foruimg = Request["FsectionImg"];
                  
                    if (foruimg != null)
                    {
                        string filePath = foruimg;
                        string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\Images\essay\") + filename;
                        string relativepath = @"/Images/essay/" + filename;
                        file.SaveAs(serverpath);
                        forumssde.FsectionImg = relativepath;
                    }
                    else
                    {
                        return Content("<script>;alert('请先上传军吧图片！');history.go(-1)</script>");

                    }
                    var forubackimg = Request["FsectionbackImg"];
                    if (forubackimg != null)
                    {
                        string filePath = forubackimg;
                        string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\Images\essay\") + filename;
                        string relativepath = @"/Images/essay/" + filename;
                        file.SaveAs(serverpath);
                        forumssde.FsectionbackImg = relativepath;
                    }
                    else
                    {
                        return Content("<script>;alert('请先军吧背景图片！');history.go(-1)</script>");

                    }
                }

                if (ModelState.IsValid)
                {
                    forumssde.ForumSectionName = forummi;
                    forumssde.User_id = userid;
                    PostManage.AddForumsection(forumssde);
                    return Content("<script>;alert('创建成功！');window.location.href='/Forum/ClassifyPost'</script>");
                }

            }
            catch (DbEntityValidationException ex)
            {
                return Content(ex.Message);
            }
            return View();
        }



        public ActionResult SelectPostReply(int commpostid)
        {
            var repluy = PostManage.findallreply(commpostid);
            if (repluy == null)
            {
                return HttpNotFound();
            }
            ViewModels.ForumPost indew = new ViewModels.ForumPost();
            indew.Replypost = repluy;

            return View(indew);

        }
    }
}