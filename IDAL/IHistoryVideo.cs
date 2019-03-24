using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface IHistoryVideo
    {
        IEnumerable<HistoryVideo> FindAllVideo();
        HistoryVideo FindVideo(int id);
        IEnumerable<HistoryVideo> FindSameVideo(int classid);
        IList<HistoryVideo> SearchVideo(string keyword);
    }
}
