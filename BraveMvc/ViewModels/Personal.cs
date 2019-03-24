using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
namespace ViewModels
{
    public class Personal
    {
        public Users userde { get; set; }
        public IEnumerable<Goods> Good1 { get; set; }
        public IEnumerable<Cart> cart1 { get; set; }
    }
}