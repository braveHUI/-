using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;


namespace DAL
{
    public class SqlHistory :IHistory
    {
        BraveEntities db = new BraveEntities();
        public IEnumerable<History> FindHistory()
        {
            var data = from p in db.History select p;
            return data;
        }
        public History HistoryDetail(int id)
        {
            var data = db.History.Find(id);
            return data;
        }
        public IEnumerable<History> FindClassHistory(int classid)
        {
            var data = from p in db.History
                       where (p.HistoryClassify_id == classid)
                       select p;
            return data;
        }
       
    }
}
