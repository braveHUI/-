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
   public class HistoryManage
    {
        public static IHistory history = DataAccess.CreateHistory();
        public static IEnumerable<History> FindHistory()
        {
            return history.FindHistory();
        }
        public static History HistoryDetail(int id)
        {
            return history.HistoryDetail(id);
        }
        public static IEnumerable<History> FindClassHistory(int classid)
        {
            return history.FindClassHistory(classid);
        }
    }
}
