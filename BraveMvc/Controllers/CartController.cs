using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using BLL;
using Models;
using ViewModels;

namespace BraveMvc.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        // GET: Cart
        [HttpPost]
        public String AddCart(Cart carts)
        {
            int goodid =int.Parse( Request["goodsid"]);
            decimal price = decimal.Parse(Request["price"].ToString());
            int userid = int.Parse(Session["User_id"].ToString());
            int num = int.Parse(Request["Jm_Amount"]);
            var goodscart = CartManage.Findgoodscart(userid, goodid);
          
                if (goodscart >=1)
                {
                    var usergoods = CartManage.findsusergoodcart(userid, goodid);
                    usergoods.CartCount = usergoods.CartCount+num;
                    usergoods.Total = price * usergoods.CartCount;
                    CartManage.Update(usergoods);
                    return "ok";
                }
                else
                {
                    carts.User_id = userid;
                    carts.Goods_id = goodid;
                    carts.Price = price;
                    carts.CartCount = num;
                    carts.Total = price * num;
                    CartManage.AddCart(carts);
                    return "ok";
                }
               
            
         
        }
        [HttpPost]
        public string updatecart(int id, string num)
        {
          
            var number = Convert.ToInt32(num);
            var cartss = CartManage.findcartid(id);
            if (cartss != null)
            {
                cartss.CartCount = number;
                cartss.Total = decimal.Parse((number * cartss.Price).ToString());
                CartManage.Update(cartss);
                
                return "success";
            }
            else
            {
                return "fail";
            }
           

        }
        [HttpPost]
        public string delete(int id)
        {
            CartManage.Delete(id);
            return "success";
        }
       
        [HttpPost]
      public string updatetotal(int id)
        {
            var cartss = CartManage.findcartid(id);
            if (cartss != null)
            {
                cartss.Flog = true;
                CartManage.Update(cartss);
                return "success";
            }
            else
            {
                return "fail";
            }
           

        }
      

        public ActionResult Address()
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            var adduse = AddressManage.seuseadd(userid);
            MallsCart ind = new MallsCart();
            ind.Address1 = adduse;
            return View(ind);

        }
        public ActionResult Address1()
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            var adduse = AddressManage.seuseadd(userid);
            MallsCart ind = new MallsCart();
            ind.Address3 = adduse;
            return View(ind);
        }
        [HttpPost]
      public ActionResult Address(Address addre)
        {
            int  userid = Convert.ToInt32(Session["User_id"]);
            string name = Request["address_name"];
            string dizhi = Request["s_province"];
            string city = Request["s_city"];
            string county = Request["s_county"];
            string zhuque = Request["address_weizi"];
            string phone =Request["address_phone"];
            int code = Convert.ToInt32(Request["address_code"]);
            addre.User_id = userid;
            addre.AddressName = name;
            addre.AddressDe = dizhi+city+county+zhuque;
            addre.AddressCode = code;
            addre.Addressphone = phone;
            AddressManage.Addaddre(addre);
            return Content("<script>;alert('提交成功');history.go()</script>");
        }
        [HttpPost]
        public String seleadrd(int id)
        {
           
            var cde = AddressManage.selectaddid(id);
            if (cde.flat != true)
            {
                int userid = Convert.ToInt32(Session["User_id"]);
                var sfdd = AddressManage.selectaaduse(userid);
                if (sfdd!=null)
                {
                    sfdd.flat = false;
                    AddressManage.update(sfdd);
                }
               
                cde.flat = true;
                AddressManage.update(cde);
                return "ok";
            }
            else
            {
                return "ok";
            }

            

        }
        public ActionResult deleteaddre(int id)
        {
            AddressManage.delete(id);
            return RedirectToAction("Address", "Cart");
        }

        public ActionResult SelectCarts()
        {
            var userid = int.Parse((Session["User_id"]).ToString());
            var carts = CartManage.Findusercart(userid);
            //ViewModels.MallsCart inde = new MallsCart();
            //inde.Carts1 = carts;
            return View(carts);
        }
        
    }
}