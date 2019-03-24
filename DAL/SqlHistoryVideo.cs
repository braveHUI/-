using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
  public class SqlHistoryVideo:IHistoryVideo
    {
        BraveEntities db = new BraveEntities();
        public IEnumerable<HistoryVideo> FindAllVideo()
        {
            var data = from p in db.HistoryVideo select p;
            return data;
        }
        public HistoryVideo FindVideo(int id)
        {
            var data = db.HistoryVideo.Find(id);
            return data;
        }
        public IEnumerable<HistoryVideo> FindSameVideo(int classid)
        {
            var data = from p in db.HistoryVideo
                       where p.VideoClassify_id == classid
                       select p;
            return data;
        }
        public IList<HistoryVideo> SearchVideo(string keyword)
        {
            var data=db.HistoryVideo.Where(p => p.Keyword.Contains(keyword));
            return data.ToList();
        }
    }
}
