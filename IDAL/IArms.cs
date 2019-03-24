using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public  interface IArms
    {

        IEnumerable<ArmsSection> FindAllSection();
        IEnumerable<Arms> FindAllArms();
        IEnumerable<AFilterSection> FindAllFilterSection();
      Arms FindArmsId(int id);
        ArmsSection FindSectionname(int id);

        //IEnumerable<Arms> findarms();


    }
}
