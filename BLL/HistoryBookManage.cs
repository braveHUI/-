using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using DALFactory;
using IDAL;

namespace BLL
{
   public class HistoryBookManage
    {
        public static IHistoryBook historybook = DataAccess.CreateHistoryBook();
        public static IEnumerable<HistoryBook> FindAllBook()
        {
           return historybook.FindAllBook();
        }
        public static HistoryBook FindBook(int id)
        {
            return historybook.FindBook(id);
        }
        public static IEnumerable<HistoryBook> FindClassBook(int classid)
        {
            return historybook.FindClassBook(classid);
        }
    }
}
