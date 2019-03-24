using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class Brave
    {
        public IEnumerable<RedSpots> spots1 { get; set; }
        public IEnumerable<Goods> Good1 { get; set; }
        public IEnumerable<News> new1 { get; set; }
        public IEnumerable<RedShare> Share { get; set; }
        public IEnumerable<RedSection> RedSection1 { get; set; }
        public RedSpots redde1 { get; set; }
        public IEnumerable<RedShare> redshare1 { get; set; }
        public RedShare redsharede { get; set; }
        

        public IEnumerable<MilitaryVideo> Video { get; set; }
        public IEnumerable<CommentRedSpots> Commred1 { get; set; }
        public IEnumerable<ReplyRedSpots> Repred1 { get; set; }
        public IEnumerable<HistoryVideo> Video1 { get; set; }
        public IEnumerable<History> history { get; set; }
    }
}