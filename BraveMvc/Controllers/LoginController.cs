using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using Models;
using BLL;

namespace BraveMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public String Index(Users user, string returnUrl)
        {
            
           
                Users users = UsersManage.Login(user);
                if (users != null)
                {

                    HttpContext.Session["User_id"] = users.User_id;
                    HttpContext.Session["Image"] = users.UserImage;
                    HttpContext.Session["Account"] = users.UserAccount;
                    HttpContext.Session["UserName"] = users.UserName;
                    return "ok";
                    
                }
                else
                {
                    return "no";
                }
           
           
            
        }
    }
}