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
   public class BraveManage
    {

        public static IBrave brave = DataAccess.Createbrave();
        public static IEnumerable<News> FindAllNews()
        {
            return brave.FindAllNews();
        }
        public static IEnumerable<MilitaryVideo> FindAllvideo()
        {
            return brave.FindAllvideo();
        }
        public static IEnumerable<History> FindAllhistory()
        {
            return brave.FindAllhistory();
        }
        public static IEnumerable<HistoryVideo> FindAllvideo1()
        {
            return brave.FindAllvideo1();
        }
        public static IEnumerable<RedSpots> FindAllSpots()
        {
            return brave.FindAllSpots();
        }
        public static IEnumerable<RedSection> FindAllSection()
        {
            return brave.FindAllSection();
        }
        public static IEnumerable<RedShare> FindAllShare()
        {
            return brave.FindAllShare();
        }
        public static IList<AFilterSection> GetAFilterId(int id)
        {
            return brave.GetAFilterId(id);
        }
        public static RedSpots FindRedId(int id)
        {
            return brave.FindRedId(id);
        }
        public static IEnumerable<RedShare> FindShareid(int id)
        {
            return brave.FindShareid(id);
        }
        public static RedShare FindSharede(int id)
        {
            return brave.FindSharede(id);
        }
        public static int findcoment(int id)
        {
            return brave.findcoment(id);
        }
    }
}
