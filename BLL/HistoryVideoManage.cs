using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Models;
using IDAL;
namespace BLL
{
   public class HistoryVideoManage
    {
        public static IHistoryVideo historyvideo = DataAccess.CreateHistoryVideo();
        public static IEnumerable<HistoryVideo> FindAllVideo()
        {
            return historyvideo.FindAllVideo();
        }
        public static HistoryVideo FindVideo(int id)
        {
            return historyvideo.FindVideo(id);
        }
        public static IEnumerable<HistoryVideo> FindSameVideo(int classid)
        {
            return historyvideo.FindSameVideo(classid);
        }
        public static IEnumerable<HistoryVideo> SearchVideo(string keyword)
        {
            return historyvideo.SearchVideo(keyword);
        }
    }
}
