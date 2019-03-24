using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlHistoryBook:IHistoryBook
    {
        BraveEntities db = new BraveEntities();
        public IEnumerable<HistoryBook> FindAllBook()
        {
            var data = from p in db.HistoryBook select p;
            return data;
        }
        public HistoryBook FindBook(int id)
        {
            var data = db.HistoryBook.Find(id);
            return data;
        }
        public IEnumerable<HistoryBook> FindClassBook(int classid)
        {
            var data = from p in db.HistoryBook
                       where p.BookClassify_id == classid
                       select p;
            return data;
        }
    }
}
