using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface IHistoryBook
    {
        IEnumerable<HistoryBook> FindAllBook();
        HistoryBook FindBook(int id);
        IEnumerable<HistoryBook> FindClassBook(int classid);
    }
}
