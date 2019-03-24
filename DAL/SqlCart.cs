using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlCart:ICart
    {
        BraveEntities db = new BraveEntities();

        public IEnumerable<Cart> Findusercart(int userid)
        {
            return db.Cart.Where(p => p.User_id == userid);
        }
        public int Findgoodscart(int userid, int goodsid)
        {
           return db.Cart.Where(p=>p.User_id==userid).Where(l => l.Goods_id == goodsid).Select(o=>o.Cart_id).Count();
        }
        public Cart findsusergoodcart(int userid, int goodsid)
        {
            Cart crts = db.Cart.Where(p => p.User_id == userid).Where(l => l.Goods_id == goodsid).FirstOrDefault();
            return crts;
        }
        public Cart findcartid(int cartid)
        {
            return db.Cart.Where(p => p.Cart_id == cartid).FirstOrDefault();
        }
        public void AddCart(Cart carts)
        {
            carts.Addtime = DateTime.Now;
            
            db.Cart.Add(carts);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Cart cart = db.Cart.Single(p => p.Cart_id == id);
            db.Cart.Remove(cart);
            db.SaveChanges();
        }
        public void Update(Cart carts)
        {
            db.Entry<Cart>(carts).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void AddOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
          
            order.State = "未支付";
            db.Order.Add(order);
            db.SaveChanges();
        }
       public void Updateorder(Order order)
        {
            db.Entry<Order>(order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public Order findOrder(int id)
        {
            return db.Order.Single(p => p.Order_id == id);

        }
       public void delete(int id)
        {
            var orde = db.Order.Single(p => p.Order_id == id);
            db.Order.Remove(orde);
            db.SaveChanges();
        }
        public IEnumerable<Order> finallorder(int userid)
        {
            return db.Order.Where(p => p.User_id == userid);
        }
    }
}
