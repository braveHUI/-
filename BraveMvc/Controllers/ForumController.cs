using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using BLL;
using Models;
using ViewModels;


namespace BraveMvc.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Index()
        {
            var milidevideo = ForumManage.findallvideo().OrderByDescending(p => p.MilitaryVideoTime).Skip(6).Take(12);
            var essay1 = ForumManage.selectallforum().Where(p => p.User_id == 1).FirstOrDefault();
            var essay2 = ForumManage.selectallforum().Where(p => p.User_id == 2).FirstOrDefault();
            var essay3 = ForumManage.selectallforum().Where(p => p.User_id ==2003).FirstOrDefault();
            var forusec1 = ForumManage.selectsec().Skip(9).Take(1).FirstOrDefault();
            var forusec2 = ForumManage.selectsec().Skip(10).Take(1).FirstOrDefault();
            var forusec3 = ForumManage.selectsec().Skip(12).Take(1).FirstOrDefault();
            var forusec4 = ForumManage.selectsec().Skip(14).Take(1).FirstOrDefault();
            ForumEssay inder = new ForumEssay();
            inder.Forum5 = essay1;
            inder.Forum6 = essay2;
            inder.Forum7 = essay3;
            inder.MiliVideo9 = milidevideo;
            inder.ForumSection6 = forusec2;
            inder.ForumSection7 = forusec3;
            inder.ForumSection8 = forusec1;
            inder.ForumSection9 = forusec4;
            return View(inder);
        }
        public ActionResult ClassifyEssay()
        {
            var foru = ForumManage.selectsec().Take(6);
            var foreess = ForumManage.selectallforum().OrderByDescending(p=>p.ForumClicks).Take(6);
            var post = PostManage.selectallpost().OrderByDescending(p=>p.Post_Click).Take(6);
            ForumEssay indee = new ForumEssay();
            indee.Section1 = foru;
            indee.Forum3 = foreess;
            indee.Post1 = post;
            return View(indee);
        }  
        public ActionResult EssayDetail(int? id)
        {
            var esst = ForumManage.selectforum(id);
            var essaycomm = ForumManage.findallcomment(id);
            var userid = Convert.ToInt32(Session["user_id"]);
            int collectionsdea;
            if (userid > 0)
            {
                var sdedq = AttentionManage.selectcollec(userid, id);
                if (sdedq != null)
                {
                    collectionsdea = 1;
                }
                else
                {
                    collectionsdea = 0;
                }

            }
            else
            {
                collectionsdea = 0;
            }
            if (esst == null)
            {
                return HttpNotFound();
            }
            ViewBag.collection = collectionsdea;
            ForumEssay indepp = new ForumEssay();
            indepp.Forum2 = esst;
            indepp.commForum1 = essaycomm;

            return View(indepp);
        }

        //文章关注
        [HttpPost]
        public string AddAttention(Attention attention, int buserid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            var sdesdw = AttentionManage.selecatten(userid, buserid);
            if (sdesdw == null)
            {
                attention.User_id = userid;
                attention.BUser_id = buserid;
                AttentionManage.Addatten(attention);
                return "success";
            }
            else
            {
                return "fail";
            }

          
        }
        [HttpPost]
        public string DeleteAttention(int buserid)
        {
           
            if (buserid >0)
            {

                AttentionManage.deleteadd(buserid);
                return "success";
            }
            else
            {
                return "fail";
            }


        }

        //文章收藏
        [HttpPost]
        public string AddCollection(Collection collection, int forumid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            var sdeqdw = AttentionManage.selectcollec(userid, forumid);
            if (sdeqdw != null)
            {
                return "fail";
            }
            else
            {
                collection.User_id = userid;
                collection.Forum_id = forumid;
                AttentionManage.Addcollection(collection);
                return "success";
            }
        }

        //文章评论
        [HttpPost]
        [ValidateInput(false)]
        public string AddEssayCommend(CommentForum forum,string essaycontent, string forumid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            var forumdew = Convert.ToInt32(forumid);
            if(!string.IsNullOrEmpty(essaycontent))
            {
                forum.Content = essaycontent;
                forum.Forum_id = forumdew;
                forum.User_id = userid;
                ForumManage.AddCommentEssay(forum);
                return "success";
            }
            else
            {
                return "fail";
            }
        }

        //删除评论
        public string DeleteCommentVideo(int id)
        {
            if (id > 0)
            {
                ForumManage.DeleteCommend(id);
                return "success";
            }
            else
            {
                return "fail";
            }

        }

      

        //更新点赞
        [HttpPost]
        public string UpdateVideoParise(int id)
        {
            var commde = ForumManage.findcommforum(id);
            if (commde != null)
            {
                commde.CommentForumParise = commde.CommentForumParise + 1;
                ForumManage.UpdateCommend(commde);
                return "success";
            }
            else
            {
                return "fail";
            }
        }

       //增加 回复
        [HttpPost]
        [ValidateInput(false)]
        public string AddReplyVideo(ReplyForum repmilivideo, string conntent, string id, string commuser)
        {
            var comnid = Convert.ToInt32(id);
            var userid = Convert.ToInt32(Session["User_id"]);
            if (!string.IsNullOrEmpty(conntent))
            {
                repmilivideo.Content = conntent;
                repmilivideo.CommentForum_id = comnid;
                repmilivideo.CommentUserName = commuser;
          
                repmilivideo.User_id = userid;
                ForumManage.addReplyForum(repmilivideo);
                return "success";
            }
            else
            {
                return "fail";
            }


        }
          

        //回复获取
        public ActionResult SelectVideoReply(int commvideoid)
        {

            var repluy = ForumManage.findallreply(commvideoid);
            if (repluy == null)
            {
                return HttpNotFound();
            }
            ViewModels.ForumEssay indew = new ForumEssay();
            indew.RepForum1 = repluy;

            return View(indew);
        }
        //回复点赞更新
        public string UpdateReplyVideoParise(int id)
        {
            var commde = ForumManage.findreplyforum(id);
            if (commde != null)
            {
                commde.ReplyForumParise = commde.ReplyForumParise + 1;
                ForumManage.UpdateRely(commde);
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        //删除回复

        [HttpPost]
        public string DeleteReplyVideo(int id)
        {
            if (id > 0)
            {
                ForumManage.DeleteReply(id);
                return "success";
            }
            else
            {
                return "fail";
            }

        }


        //视屏分类
        public ActionResult ClassifyVideo()
        {
            var foru = ForumManage.selectsec().Take(3);
            var forw = ForumManage.selectsec().Skip(4);
           
            ForumVideo index = new ForumVideo();
            index.Forsection = foru;
            index.Forsection1 = forw;
            return View(index);
        }
        public ActionResult ClassifyPost()
        {
            var pose = PostManage.selectallpost();
           
            var usrid = Convert.ToInt32(Session["User_id"]);
            ForumPost idesw = new ForumPost();
            if (usrid > 0)
            {
                var userinfo = UsersManage.finduser(usrid);
                var atte = AttentionManage.selectattenpost(usrid);
                if (atte != null)
                {
                 idesw.AttentionPost1 = atte;
                }
                idesw.Userinfo = userinfo;
               
            }
           
          
            idesw.Post1 = pose;
            return View(idesw);
        }
        public ActionResult JunBa(int id,string search_internal_input)
        {
            var sdedw = PostManage.findforumsec(id);
            var userid = Convert.ToInt32(Session["user_id"]);
            var forupost = PostManage.selectzhepost(id);
            var userinfo = UsersManage.finduser(userid);
            var postef = PostManage.selectallpost().OrderByDescending(p => p.Post_Click).Take(5);
            if (!String.IsNullOrEmpty(search_internal_input))
            {
                forupost = forupost.Where(s => s.PostName.Contains(search_internal_input)||s.PostContent.Contains(search_internal_input) );
            }

            int attentionposet;
            int signtrue;
            int attenid;
            if (userid > 0)
            {
              
                var sdedq = AttentionManage.selectattenpostforu(userid, id);
                var sdedfdf = AttentionManage.findsign(userid, id);
                if (sdedq != null)
                {
                    attenid = sdedq.AttentionPost_id;
                    ViewBag.attentionid = attenid;
                    attentionposet = 1;
                }
                else
                {
                    attentionposet = 0;
                }
                if (sdedfdf != null)
                {
                    signtrue = 1;
                    ViewBag.signtime = sdedfdf.SignatureTime;
                }
                else
                {
                    signtrue = 0;
                }

            }
            else
            {
                attentionposet = 0;
                signtrue = 0;
            }
            ViewBag.atten = attentionposet;
            ViewBag.signid= signtrue;
            ViewBag.allcontgun = AttentionManage.findattenjisuan(id);
            ViewBag.postcount = AttentionManage.findallpost(id);
            ForumPost idnes = new ForumPost();
            idnes.ForumSEC1 = sdedw;
            idnes.Post1 = forupost;
            idnes.Post2 = postef;
            if (userinfo != null)
            {
                idnes.Userinfo1 = userinfo;
            }
           
            return View(idnes);
        }
        //军吧关注
        [HttpPost]
        public string Addattentionpost(AttentionPost attenpos, int id)
        {
          
                var userid = Convert.ToInt32(Session["User_id"]);
                if (id > 0)
                {
                attenpos.User_id = userid;
                attenpos.ForumSection_id = id;
                AttentionManage.Addattenpost(attenpos);
                    
                   
                    return "success";
                }
                else
                {
                    return "fail";
                }
            
         


        }
        //军吧取消关注
        public string DeleteGuan(int id)
        {
            if (id > 0)
            {
                AttentionManage.deleteaddpost(id);
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        //君吧签到
        [HttpPost]
        public string AddSign(Signature signt, int id)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            if (id > 0)
            {
                signt.ForumSection_id = id;
                var sssude = UsersManage.finduser(userid);
                if (sssude != null)
                {
                    sssude.Integral = sssude.Integral + 10;
                    UsersManage.updateuser(sssude);
                }

                signt.User_id = userid;
                AttentionManage.AddSign(signt);
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        //发表帖子
       
        public ActionResult PostDetail(int id)
        {
            var sdew = PostManage.selectpost(id);
            var postef1 = PostManage.selectallpost().OrderByDescending(p => p.Post_Click).Skip(6).Take(5);
            var buser = sdew.User_id;
            var userid = Convert.ToInt32(Session["User_id"]);
            var commdpost = PostManage.findallcomment(id);
            int attef;
            ForumPost indew = new ForumPost();
            if (userid > 0)
            {
                var atter = AttentionManage.selecatten(userid, buser);
                if (atter != null)
                {
                    attef = 1;
                    ViewBag.attenrenid = atter.Attention_id;
                }
                else
                {
                    attef = 0;
                }
                var userinfo1 = UsersManage.finduser(userid);
                indew.Userinfo2 = userinfo1;

            }
            else
            {
                attef = 0;
            }
            ViewBag.atterceshi = attef;
            indew.Post7 = postef1;
            indew.Post5 = sdew;
            indew.Commentpost = commdpost;
            return View(indew);
        }
        [HttpPost]
        [ValidateInput(false)]
        public string AddPostComment(CommentPost commpost)
        {
            var contentpos = Request.Form["CommendPostcopne"];
            var posid = Convert.ToInt32(Request["post_idcomm"]);
            var userid = Convert.ToInt32(Session["User_id"]);
            if (!String.IsNullOrEmpty(contentpos))
            {
                commpost.Post_id = posid;
                commpost.User_id = userid;
                commpost.Content = contentpos;
                PostManage.AddCommentPost(commpost);
                return "success";
            }
            else
            {
                return "fail";
            }
          
        }
        [HttpPost]
        [ValidateInput(false)]
        public string AddPostReply(ReplyPost replypso,string content,int id,string buser)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            if (!String.IsNullOrEmpty(content))
            {
                replypso.Content = content;
                replypso.User_id = userid;
                replypso.CommentUsername = buser;
                replypso.CommentPost_id = id;
                PostManage.addReplyPost(replypso);
                return "ok";
            }
            else
            {
                return "no";
            }

           
        }





    }
}