using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
namespace ViewModels
{
    public class Cnpagelist
    {
        public IEnumerable<News> Findcountrynews { get;set; }
        public IEnumerable<News> FindAllNews { get; set; }
        public IEnumerable<News> FindInternationalNews { get; set; }
        public IEnumerable<News> FindHotNews { get; set; }
        public News FindDetailNews {get; set;}
        public IEnumerable<News> FindClassifyNews { get; set; }
        public IEnumerable<News> SelectNews { get; set; }
        public News FindPreNews { get; set; }
        public News FindNextNews { get; set; }
        public  IQueryable<CommentNews> FindAllComment { get; set; }         
        public IQueryable<ReplyNews> FindAllReply { get; set; }                
      



    }
}