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
   public   class ArmsManage
    {


        public static IArms Arms = DataAccess.CreateArms();
        public static IEnumerable<ArmsSection> FindAllSection()
        { 
            return Arms.FindAllSection();
        }
        public static IEnumerable<Arms> FindAllArms()
        {
            return Arms.FindAllArms();
        }
        public static IEnumerable<AFilterSection> FindAllFilterSection()
        {
            return Arms.FindAllFilterSection();
        }
        //public static IEnumerable<Arms> findarms()
        //{
        //    return Arms.findarms();
        //}
        public static Arms FindArmsId(int id)
        {
            return Arms.FindArmsId(id);
        }
        public static ArmsSection FindSectionname(int id)
        {
            return Arms.FindSectionname(id);
        }
    }
}
