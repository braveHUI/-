using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public  interface IBrave
    {
        IEnumerable<RedSpots> FindAllSpots();
        IEnumerable<RedShare> FindAllShare();
        IEnumerable<News> FindAllNews();
        IEnumerable<RedSection> FindAllSection();
        IList<AFilterSection> GetAFilterId(int id);
        RedSpots FindRedId(int id);//景点详情
        IEnumerable<RedShare> FindShareid(int id);//某景点的分享
        RedShare FindSharede(int id);//游记详情
        IEnumerable<MilitaryVideo> FindAllvideo();
        IEnumerable<HistoryVideo> FindAllvideo1();
        IEnumerable<History> FindAllhistory();
        int findcoment(int id);
    }
}
