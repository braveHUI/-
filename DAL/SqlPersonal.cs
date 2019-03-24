using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
    public  class SqlPersonal:IPersonal

    {
        BraveEntities db = new BraveEntities();
        public Users FinduserId(int id)
        {
            return db.Users.Single(p => p.User_id == id);
        }
        public IEnumerable<Cart> findcart(int id)
        {
            return db.Cart.Where(p => p.User_id==id).ToList();
        }

        public int findcarticount(int id)
        {
            return db.Cart.Where(p => p.User_id == id).Count();
        }
    }
}
