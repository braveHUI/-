using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class Armss
    {

        public IEnumerable<ArmsSection> armSection { get; set; }
        public IEnumerable<Arms> arms { get; set; }
        public IEnumerable<Arms> arms1 { get; set; }
        public Arms armsde { get; set; }
        public ArmsSection armsectionid { get; set; } 
        public IEnumerable<AFilterSection> aFilterSection { get; set; }
        public IEnumerable<AFilterSection> aFilterSection2 { get; set; }
        public IEnumerable<AFilterSection> aFilterSection3 { get; set; }
    }
}