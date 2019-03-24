using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface ICart
    {
      
        IEnumerable<Cart> Findusercart(int userid);
       int Findgoodscart(int userid,int goodsid);
        Cart findsusergoodcart(int userid, int goodsid);
        Cart findcartid(int cartid);
        void AddCart(Cart carts);
        //Cart getCart(int id);
        void Delete(int id);
        void Update(Cart carts);
        void AddOrder(Order order);
        void Updateorder(Order order);
        Order findOrder(int id);
        IEnumerable<Order> finallorder(int userid);
        void delete(int id);
       

    }
}
