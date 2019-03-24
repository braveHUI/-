using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlCommentNews:ICommentNews
    {
        BraveEntities db = new BraveEntities();
        
       public void AddComment(CommentNews commnews)
        {
            commnews.CommentTime = DateTime.Now;
            db.CommentNews.Add(commnews);
            db.SaveChanges();

        }
        public IQueryable<CommentNews> FindAllComment(int? id)
        {
            return db.CommentNews.Where(p => p.News_id == id);
        }
       public void UpdateCommend(CommentNews commnews)
        {
            db.Entry<CommentNews>(commnews).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCommend(int id)
        {
            CommentNews conew = db.CommentNews.Single(p => p.CommentNews_id == id);
            db.CommentNews.Remove(conew);
            db.SaveChanges();
        }
         public void AddReplyNews(ReplyNews replynew)
        {
            replynew.ReplyTime = DateTime.Now;
            db.ReplyNews.Add(replynew);
            db.SaveChanges();
        }
       public IQueryable<ReplyNews> FindAllReply(int id)
        {
            return db.ReplyNews.Where(p => p.CommentNews_id == id);
        }
       public void UpdateRely(ReplyNews replynew)
        {
            db.Entry<ReplyNews>(replynew).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteReply(int id)
        {
            ReplyNews repnews = db.ReplyNews.Single(p => p.ReplyNews_id == id);
            db.ReplyNews.Remove(repnews);
            db.SaveChanges();
        }
       public int Countmiti(int id)
        {
            return db.CommentNews.Count(p => p.News_id == id);
        }
       public int Countrep(int id)
        {
            return db.ReplyNews.Count(p => p.CommentNews_id==id);
        }

       public CommentNews FindCommNews(int id)
        {
            return db.CommentNews.Single(p => p.CommentNews_id == id);
        }
       public ReplyNews FindReplyNews(int id)
        {
            return db.ReplyNews.Single(p => p.ReplyNews_id == id);
        }
    }
}
