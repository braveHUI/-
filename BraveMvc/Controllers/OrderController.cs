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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            var cart = CartManage.Findusercart(userid).Where(p=>p.Flog==true);
            decimal sum=0;
            decimal a;
             foreach (var item in cart)
            {
                var sdsd = cart.FirstOrDefault(p => p.Cart_id == item.Cart_id);
                if (sdsd != null)
                {
                   a = sdsd.Total;
                  sum = sum+a;
                  
                }
                
            }
            ViewBag.count = sum;
            var orde = AddressManage.selectaaduse(userid);
            MallsCart ind = new MallsCart();
            ind.Carts2 = cart;
            ind.Address2 = orde;
            return View(ind);
        }
        public ActionResult SelectOrder()
        {
            int userid =Convert.ToInt32(Session["User_id"]);
            var ordert = CartManage.finallorder(userid).OrderByDescending(o=>o.OrderTime).Where(u=>u.Site_id==2).Take(1);
            var orde = AddressManage.selectaaduse(userid);
            MallsCart ind = new MallsCart();
            ind.Order1 = ordert;
            ind.Address4 = orde;
            return View(ind);
        }

        public ActionResult Addorder(Order order)
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            var message = Request["order-messagessss"];
            var cart = CartManage.Findusercart(userid).Where(p => p.Flog == true);
            foreach (var item in cart) 
            {
                var sdsd = cart.FirstOrDefault(p => p.Cart_id == item.Cart_id);
                order.Good_id = sdsd.Goods_id;
                order.Message = message;
                order.Price = sdsd.Price;
                order.User_id = userid;
                order.TotalMoney = sdsd.Total;
                order.Amount = sdsd.CartCount;
                order.Site_id = 1;

                CartManage.Delete(sdsd.Cart_id);
                CartManage.AddOrder(order);
                

            }
            return Content("<script>;alert('订单提交成功'); window.location.href ='/Malls/Index'</script>");
        }



        [HttpPost]
        public String Deleteorder(int orderid)
        {
            CartManage.delete(orderid);
            return "ok";
        }
        [HttpPost]
        public String updateOrder(int orderid,string messsage)
        {
            var ordero = CartManage.findOrder(orderid);
            ordero.Message = messsage;
            ordero.State = "已支付，请等待收货";
            ordero.Site_id = 1;
            CartManage.Updateorder(ordero);
            return "ok";
        }
    }
}