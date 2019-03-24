using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
   public  class SqlBrave:IBrave
    {

        BraveEntities db = new BraveEntities();
        public IEnumerable<News> FindAllNews()
        {
            return db.News.ToList();
        }

        public IEnumerable<MilitaryVideo> FindAllvideo()
        {
            return db.MilitaryVideo.ToList();
        }
        public IEnumerable<HistoryVideo> FindAllvideo1()
        {
            return db.HistoryVideo.ToList();
        }
        public IEnumerable<History> FindAllhistory()
        {
            return db.History.ToList();
        }
        public IEnumerable<RedSpots> FindAllSpots()
        {
            return db.RedSpots.ToList();
        }
        public IEnumerable<RedShare> FindAllShare()
        {
            return db.RedShare.ToList();
        }
        public IEnumerable<RedSection> FindAllSection()
        {
            return db.RedSection.ToList();
        }
        public IList<AFilterSection> GetAFilterId(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;//序列化类型 System.Data.Entity.DynamicProxies 的对象时检测到循环引用 
            return db.AFilterSection.Where(p => p.ArmsSection_id == id).ToList();
        }
        public RedSpots FindRedId(int id)
        {
            return db.RedSpots.Single(p => p.RedSpots_id == id);
        }
        public IEnumerable<RedShare> FindShareid(int id)
        {
            return db.RedShare.Where(p => p.RedSpots_id == id).ToList();
        }
        public RedShare FindSharede(int id)
        {
            return db.RedShare.Single(p => p.RedShare_id == id);
        }
        public int findcoment(int id)
        {
            return db.CommentRedSpots.Where(p => p.RedSpots_id == id).Count();
        }
    }
}
