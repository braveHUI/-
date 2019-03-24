using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUsers
    {
        Users Findname(Users user);
        void Register(Users user);
        void updateuser(Users user);
        Users Login(Users user);
        Users finduser(int id);


    }
}
