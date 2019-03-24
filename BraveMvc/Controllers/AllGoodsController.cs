using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;
using IDAL;
using DALFactory;
using ViewModels;


namespace BraveMvc.Controllers
{
    public class AllGoodsController : Controller
    {
        // GET: AllGoods
        public ActionResult Index(String classifyInfoFrom, String SortInfoFrom, string currentFilter, int? page)
        {
           
            var goods = GoodsManage.FindGoods();
            if (classifyInfoFrom != null)
            {
                Session["fenlei"] = classifyInfoFrom;
            }
           
            if (classifyInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                classifyInfoFrom = currentFilter;
            }

            ViewBag.CurrentFilter = classifyInfoFrom;
            if (SortInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                SortInfoFrom = currentFilter;
            }
            ViewBag.CurrentFilter = SortInfoFrom;

            if (!string.IsNullOrEmpty(classifyInfoFrom))  //注意，判断字符串类型为空，要使用String.IsNullEmpty() 而不能使用 !=null 来判断。
            {
                goods = goods.Where(x => x.Classify.ClassifyName == classifyInfoFrom);
            }
            //ViewBag.searchString = searchString;
            if (!String.IsNullOrEmpty(SortInfoFrom))
            {
                if (Session["fenlei"] != null)
                {
                    var clssif = Session["fenlei"].ToString();
                    if (SortInfoFrom == "价格降序")
                    {
                        goods = goods.Where(x => x.Classify.ClassifyName == clssif).OrderByDescending(p => p.GoodsPrice);
                    }
                    else if (SortInfoFrom == "价格升序")
                    {
                        goods = goods.Where(x => x.Classify.ClassifyName == clssif).OrderBy(p => p.GoodsPrice);
                    }
                    else if (SortInfoFrom == "更新时间")
                    {
                        goods = goods.Where(x => x.Classify.ClassifyName == clssif).OrderByDescending(p => p.Grounding);
                    }
                }
                else
                {
                    if (SortInfoFrom == "价格降序")
                    {
                        goods = goods.OrderByDescending(p => p.GoodsPrice);
                    }
                    else if (SortInfoFrom == "价格升序")
                    {
                        goods = goods.OrderBy(p => p.GoodsPrice);
                    }
                    else if (SortInfoFrom == "更新时间")
                    {
                        goods = goods.OrderByDescending(p => p.Grounding);
                    }
                }
                


            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("Index", goods.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Index", goods.ToPagedList(pageNumber, pageSize));
            }
          
        }
        public ActionResult MiliVideo(int? page, string forumsectionid, string currentFilter)
        {
            var milivideo = ForumManage.findallvideo();
            if (forumsectionid != null)
            {
                page = 1;
            }
            else
            {
                forumsectionid = currentFilter;
            }

            ViewBag.CurrentFilter = forumsectionid;
            if (!string.IsNullOrEmpty(forumsectionid))
            {
               milivideo = milivideo.Where(p => p.ForumSection.ForumSectionName == forumsectionid);
            }
            int pagesize = 9;
            int pageNum = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("MiliVideo",milivideo.ToPagedList(pageNum,pagesize));
            }
            else
            {
                return View("MiliVideo", milivideo.ToPagedList(pageNum, pagesize));
            }



            
            
        }



        public ActionResult ForuEssa(int? page, string forumsectionid, string currentFilter)
        {
            var essayfgrgr = ForumManage.selectallforum();
            if (forumsectionid != null)
            {
                page = 1;
            }
            else
            {
                forumsectionid = currentFilter;
            }

            ViewBag.CurrentFilter = forumsectionid;
            if (!string.IsNullOrEmpty(forumsectionid))
            {
                essayfgrgr = essayfgrgr.Where(p => p.ForumSection.ForumSectionName == forumsectionid);
            }
            int pagesize = 8;
            int pageNum = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ForuEssa", essayfgrgr.ToPagedList(pageNum, pagesize));
            }
            else
            {
                return View("ForuEssa", essayfgrgr.ToPagedList(pageNum, pagesize));
            }





        }
        public ActionResult Postdeadwe(int? page)
        {
            var pose = PostManage.selsectallsec().Skip(9);
            int pagesize = 9;
            int pageNum = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("Postdeadwe", pose.ToPagedList(pageNum, pagesize));
            }
            else
            {
                return View("Postdeadwe", pose.ToPagedList(pageNum, pagesize));
            }
           
           
           
        }
          

    
    }
}