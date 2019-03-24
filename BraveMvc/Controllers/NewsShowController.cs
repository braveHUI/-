using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using PagedList;
using ViewModels;
using Models;

namespace BraveMvc.NewsControllers
{
    public class NewsShowController : Controller
    {
        // GET: News
        
        public ActionResult Index2()
        {
            
            var xiaoxi = NewsManage.FindAllNews().OrderByDescending(p=>p.SubmtDate).Take(6);
            var CountryNews = NewsManage.FindCountryNews().Where(p => p.Section_id == 1).Take(16);
            var InternationalNews = NewsManage.FindInternationalNews().Where(p => p.Section_id == 2).Take(16);
            var HotNews = NewsManage.FindHotNews().Where(p => p.Section_id == 3).Take(16);
            ViewModels.Cnpagelist index = new ViewModels.Cnpagelist();
            index.Findcountrynews = CountryNews;
            index.FindAllNews = xiaoxi;
            index.FindInternationalNews = InternationalNews;
            index.FindHotNews = HotNews;
            return View(index);
        }
        public ActionResult Detail(int id)
        {

            var detail = NewsManage.FindDetailNews(id);                                              
            var commend = CommentNewsManage.FindAllComment(id);            
            var pre = NewsManage.FindPreNews(id);
          
            if (pre==null)
            {
                return Content("<script>;alert('到顶了!');</script>");
            }
            var next = NewsManage.FindNextNews(id);
           
            if (next==null)
            {
                return Content("<script>;alert('到底了!');</script>");
            }
            ViewBag.coutcommend = CommentNewsManage.Countmiti(id);                              
            ViewModels.Cnpagelist index = new ViewModels.Cnpagelist();
            index.FindDetailNews = detail;         
            index.FindPreNews = pre;
            index.FindNextNews = next;
            index.FindAllComment = commend;                       
            return View(index);
        }
        public ActionResult Details(string search_internal_input)
        {

           
            if (!String.IsNullOrEmpty(search_internal_input))
            {
                var selectnews = NewsManage.SelectNews(search_internal_input);
                return PartialView("Details", selectnews);
            }
            else{
                return View();
            }


          
        }
       public ActionResult ClassifyNews()
        {
            var classify = NewsManage.FindClassifyNews().Where(p => p.Section_id == 1).OrderByDescending(p => p.News_id);                                                     
            return View(classify);
        }       
        [HttpPost]
        [ValidateInput(false)]
        public string AddCommentNews(CommentNews commnews,string newcontent,int id)
        {
            var useid = Convert.ToInt32(Session["User_id"]);
           
            
            if (newcontent != null && newcontent.Length > 0)
            {
                commnews.User_id = useid;
                commnews.News_id = id;
                commnews.Content = newcontent;              
                CommentNewsManage.AddComment(commnews);
                return "success";
            }
            else
            {
                return "fail";
            }

        }
        [HttpPost]
        public string DeleteCommentNews(int id)
        {
            if (id > 0)
            {
               CommentNewsManage.DeleteCommend(id);
                return "success";
            }
            else
            {
                return "fail";
            }

        }     

        [HttpPost]
        [ValidateInput(false)]
        public string AddReplyNews(ReplyNews replynew, string conntent, string id, string commuser)
        {
            var comnid = Convert.ToInt32(id);
            var userid = Convert.ToInt32(Session["User_id"]);
            if (!string.IsNullOrEmpty(conntent))
            {
                replynew.Content = conntent;
                replynew.CommentNews_id = comnid;
                replynew.CommentUserName = commuser;
                replynew.User_id = userid;
                CommentNewsManage.AddReplyNews(replynew);
                return "success";
            }
            else
            {
                return "fail";
            }


        }

        public ActionResult SelectNewsReply(int id)
        {

            var repluy =CommentNewsManage.FindAllReply(id);
            if (repluy == null)
            {
                return HttpNotFound();
            }
            ViewModels.Cnpagelist indew = new Cnpagelist();
            indew.FindAllReply = repluy;

            return View(indew);
        }      

        [HttpPost]
        public string DeleteReply(int id)
        {
            if (id > 0)
            {
                CommentNewsManage.DeleteReply(id);
                return "success";
            }
            else
            {
                return "fail";
            }

        }

    }
}