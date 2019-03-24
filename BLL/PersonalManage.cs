using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using DAL;
using Models;

namespace BLL
{
    public  class PersonalManage
    {

        public static IPersonal per = DataAccess.CreatePersonal();
        public static Users FinduserId(int id)
        {
            return per.FinduserId(id);
        }
        public static IEnumerable<Cart> findcart(int id)
        {
            return per.findcart(id);
        }
        public static int findcarticount(int id)
        {
            return per.findcarticount(id);
        }
    }
}
