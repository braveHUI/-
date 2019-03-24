using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class Clasaifymenu
    {
        public IEnumerable<Goods> Goodsss { get; set; }
        public IEnumerable<Classify> Classify1 { get; set; }
        public IEnumerable<Cart> Carts1 { get; set; }
    }
}