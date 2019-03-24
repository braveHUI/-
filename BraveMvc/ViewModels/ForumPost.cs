using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class ForumPost
    {
        public IEnumerable<Post> Post1 { get; set; }
        public IEnumerable<Post> Post2 { get; set; }
        public IEnumerable<Post> Post3 { get; set; }
        public Post Post4 { get; set; }
        public Post Post5 { get; set; }
        public IEnumerable<Post> Post7 { get; set; }
        public IEnumerable<CommentPost> Commentpost { get; set; }
        public IEnumerable<ReplyPost> Replypost { get; set; }
        public Users Userinfo { get; set; }
        public Users Userinfo1 { get; set; }
        public Users Userinfo2 { get; set; }
        public ForumSection ForumSEC1 { get; set; }
        public IEnumerable<AttentionPost> AttentionPost1 { get; set; }


    }
}