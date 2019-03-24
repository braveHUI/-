using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class ForumNews
    {
        public IEnumerable<MilitaryVideo> Military { get; set; }
        public IEnumerable<Forum> Forum1 { get; set; }
        public IEnumerable<Forum> Forum2 { get; set; }
        public IEnumerable<Forum> Forum3 { get; set; }
        public IEnumerable<Post> Post1 { get; set; }
        public IEnumerable<Post> Post2 { get; set; }
        public IEnumerable<Post> Post3 { get; set; }
        public IEnumerable<Post> Post4 { get; set; }
    }
}