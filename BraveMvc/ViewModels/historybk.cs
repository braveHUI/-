using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class historybk
    {
        public IEnumerable<HistoryBook> FindAllBook { get; set; }
        public HistoryBook FindBook { get; set; }
        public IEnumerable<HistoryBook> FindClassBook { get; set; }
    }
}