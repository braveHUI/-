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
    public class CommunicationController : Controller
    {
        // GET: Communication
        public ActionResult Index(int? ruserid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            if (userid > 0)
            {
                var messsage = CommunicationManage.SelectCommenicatio(userid).Take(12);
                var atten = AttentionManage.selectallatten(userid);
                var atten1 = AttentionManage.selectbatten(userid);

                var timesd = Int64.Parse(DateTime.Now.ToString("yyyyMMdd")) - 1;
                CommuMessage inde = new CommuMessage();
                inde.Attention1 = atten;
                inde.Attention2 = atten1;
                inde.Communication1 = messsage;
                return View(inde);
            }
            else
            {
                return View();
            }

        }

        public ActionResult SelectMessagecomm(int ruserid)
        {
            CommuMessage inde = new CommuMessage();
            var userid = Convert.ToInt32(Session["User_id"]);

            var messaer1 = CommunicationManage.SelectMessage(userid, ruserid);
            if (messaer1 == null)
            {
                return HttpNotFound();
            }
            inde.Communication2 = messaer1;
            return View(inde);

        }
        public String Addmessage(Communication communic, string content, int ruserid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            if (userid > 0)
            {
                communic.Content = content;
                communic.RUser_id = ruserid;
                communic.User_id = userid;
                CommunicationManage.AddCommenication(communic);
                return "ok";

            }
            else
            {
                return "no";
            }

        }

        [HttpPost]
        public String Update(int id)
        {
            var commse = CommunicationManage.FindComm(id);
            if (commse != null)
            {
                commse.Flag = true;
                CommunicationManage.UpdateCommun(commse);
                return "ok";
            }
            else
            {
                return "no";
            }
        }


        public ActionResult SelectContent(int ruserid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            var message1 = CommunicationManage.SelectMessage(userid, ruserid);
            var message2 = CommunicationManage.SelectMessage(ruserid, userid);
            CommuMessage indeq = new CommuMessage();
            if (message2 != null)
            {

                indeq.Communication3 = message1;
                indeq.Communication4 = message2;

            }
            else
            {
                ViewBag.cohtenk = 1;
                indeq.Communication3 = message1;
            }




            return View(indeq);
        }
    }
}