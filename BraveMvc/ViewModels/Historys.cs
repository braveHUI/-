using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
namespace ViewModels
{
    public class Historys
    {
        public IEnumerable<History> FindHistory{ get; set; }
        public IEnumerable<HistoryVideo> FindAllVideo { get; set; }
        public IEnumerable<HistoryBook> FindAllBook { get; set; }
        public History HistoryDetail { get; set; }
        public IEnumerable<History> FindClassHistory { get; set; }
        public IEnumerable<History> FindClassName { get; set; }
    }
}