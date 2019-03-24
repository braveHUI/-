using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class historyvd
    {
        public IEnumerable<HistoryVideo> FindAllVideo { get; set; }
        public HistoryVideo FindVideo { get; set; }
        public IEnumerable<HistoryVideo> FindSameVideo { get; set; }
        public IList<HistoryVideo> SearchVideo { get; set; }
        
    }
}