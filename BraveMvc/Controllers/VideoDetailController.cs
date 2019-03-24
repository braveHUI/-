using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using ViewModels;

namespace BraveMvc.Controllers
{
    public class VideoDetailController : Controller
    {
        // GET: VideoDetail
        public ActionResult Index(int id,int seectionid)
        {
           
                var mivideo = CommentMiliVideoManage.getmivideo(id);
                var milisecc = ForumManage.findallvideo().Where(p => p.ForumSection_id == seectionid).Take(7);
                var milicommend = CommentMiliVideoManage.findallcomment(id);
                ViewBag.coutcommend = CommentMiliVideoManage.countmiti(id);
            if (mivideo == null)
            {
                return HttpNotFound();
            }
            if (milisecc == null)
            {
                return HttpNotFound();
            }
            if (milicommend == null)
            {
                return HttpNotFound();
            }
            ViewModels.ForumVideo indess = new ForumVideo();
                indess.MiliVideo1 = milisecc;
                indess.MiliVideo2 = mivideo;
                indess.CommMiliVideo = milicommend;
                return View(indess);
           
            
           
          
        }
        public ActionResult Detail(int id, int seectionid)
        {
            var mivideo = CommentMiliVideoManage.getmivideo(id);
            var milisecc = ForumManage.findallvideo().Where(p => p.ForumSection_id == seectionid).Take(7);
            var milicommend = CommentMiliVideoManage.findallcomment(id);
            if (mivideo == null)
            {
                return HttpNotFound();
            }
            if (milisecc == null)
            {
                return HttpNotFound();
            }
            if (milicommend == null)
            {
                return HttpNotFound();
            }
            ViewModels.ForumVideo indess = new ForumVideo();
            indess.MiliVideo1 = milisecc;
            indess.MiliVideo2 = mivideo;
            indess.CommMiliVideo = milicommend;
            return View(indess);
        }

        [HttpPost]
        [ValidateInput(false)]
        public string AddCommentVideo(CommendMilitaryVideo commvideo)
        {
            var useid = Convert.ToInt32(Session["User_id"]);
            string content = Request["video_content"];
            int videoid =Convert.ToInt32(Request["milivideo_id"]);
            if (content != null&&content.Length>0)
            {
                commvideo.User_id = useid;
                commvideo.MilitaryVideo_id = videoid;
                commvideo.Content = content;
                commvideo.CommVideoPaiseTotal = 1;
                CommentMiliVideoManage.AddCommentMiliVideo(commvideo);
                return "aa";
            }
            else
            {
                return "bb";
            }
            
        }
        [HttpPost]
        public string DeleteCommentVideo(int id)
        {
            if (id > 0)
            {
                CommentMiliVideoManage.DeleteCommend(id);
                return "success";
            }
            else
            {
                return "fail";
            }
           
        }
        public ActionResult Addvideopaise(CommendVideoPaise commpaise, int id)
        {
            var commvideo = id;
            var userid = Convert.ToInt32(Session["User_id"]);
            commpaise.User_id = userid;
            commpaise.CommendMilitaryVideo_id = id;
            commpaise.VideoPaiseNum = 1;
            CommentMiliVideoManage.addcommPraise(commpaise);
            return View();
        }
       [HttpPost] 
       public string UpdateVideoParise(CommendMilitaryVideo commpar,int id)
        {
            var commde = CommentMiliVideoManage.findcommvideo(id);
            if (commde != null)
            {
                commde.CommVideoPaiseTotal = commde.CommVideoPaiseTotal + 1;
                CommentMiliVideoManage.UpdateCommend(commde);
                return "success";
            }
            else
            {
                return "fail";
            }
        }


        [HttpPost]
        [ValidateInput(false)]
        public string AddReplyVideo(ReplyMilitaryVideo repmilivideo,string conntent,string id, string commuser)
        {
            var comnid = Convert.ToInt32(id);
            var userid = Convert.ToInt32(Session["User_id"]);
            if (!string.IsNullOrEmpty(conntent))
            {
                repmilivideo.Content = conntent;
                repmilivideo.CommentMilitaryVideo_id = comnid;
                repmilivideo.CommentMilitaryVideoUserName = commuser;
                repmilivideo.RepVideoPaiseTotal = 1;
                repmilivideo.User_id = userid;
                CommentMiliVideoManage.addReplyMiliVideo(repmilivideo);
                return "success";
            }
            else
            {
                return "fail";
            }

           
        }
       
         public ActionResult SelectVideoReply(int commvideoid)
        {
            
             var repluy = CommentMiliVideoManage.findallreply(commvideoid);
            if (repluy == null)
            {
                return HttpNotFound();
            }
            ViewModels.ForumVideo indew = new ForumVideo();
            indew.ReplyMiliVideo = repluy;

            return View(indew);
        }
        public string UpdateReplyVideoParise(ReplyMilitaryVideo replyvid, int id)
        {
            var commde = CommentMiliVideoManage.findreplyvideo(id);
            if (commde != null)
            {
                commde.RepVideoPaiseTotal = commde.RepVideoPaiseTotal + 1;
                CommentMiliVideoManage.UpdateRely(commde);
                return "success";
            }
            else
            {
                return "fail";
            }
        }


        [HttpPost]
        public string DeleteReplyVideo(int id)
        {
            if (id > 0)
            {
                CommentMiliVideoManage.DeleteReply(id);
                return "success";
            }
            else
            {
                return "fail";
            }

        }


        
       
    }
}