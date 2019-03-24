using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class ForumVideo
    {
        public IEnumerable<ForumSection> Forsection{ get; set; }
        public IEnumerable<ForumSection> Forsection1 { get; set; }
        public IEnumerable<MilitaryVideo> MiliVideo { get; set; }
        public IEnumerable<MilitaryVideo> MiliVideo1 { get; set; }
        public MilitaryVideo MiliVideo2 { get; set; }
        public IEnumerable<CommendMilitaryVideo> CommMiliVideo { get; set; }
        public IEnumerable<ReplyMilitaryVideo> ReplyMiliVideo { get; set; }
    }
}