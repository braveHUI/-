using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace IDAL
{
    public  interface IPersonal
    {

       Users FinduserId(int id);//个人详情

        IEnumerable<Cart> findcart(int id);

        int findcarticount(int id);
    }
}
