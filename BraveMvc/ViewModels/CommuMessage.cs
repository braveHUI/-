using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class CommuMessage
    {
        public IEnumerable<Communication> Communication1 { get; set; }
        public IEnumerable<Communication> Communication2 { get; set; }
        public IEnumerable<Communication> Communication3 { get; set; }
        public IEnumerable<Communication> Communication4 { get; set; }
        public IEnumerable<Attention> Attention1 { get; set; }
        public IEnumerable<Attention> Attention2 { get; set; }

    }
}