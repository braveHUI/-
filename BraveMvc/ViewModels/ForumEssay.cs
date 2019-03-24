using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class ForumEssay
    {
        public IEnumerable<ForumSection> Section1 { get; set; }
        public Forum Forum2 { get; set; }
        public IEnumerable<Forum> Forum1 { get; set; }
        public IEnumerable<Forum> Forum3 { get; set; }
        public IEnumerable<Post> Post1 { get; set; }
        public IEnumerable<CommentForum> commForum1 { get; set; }
        public IEnumerable<ReplyForum> RepForum1 { get; set; }

        public Forum Forum5 { get; set; }
        public Forum Forum6 { get; set; }
        public Forum Forum7 { get; set; }
        public IEnumerable<MilitaryVideo> MiliVideo9 { get; set; }
        public IEnumerable<ForumSection> ForumSection5 { get; set; }
        public ForumSection ForumSection6 { get; set; }
        public ForumSection ForumSection7 { get; set; }
        public ForumSection ForumSection8 { get; set; }
        public ForumSection ForumSection9 { get; set; }
    }
}