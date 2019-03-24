using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlForum:IForum
    {
        BraveEntities db = new BraveEntities();
        public IQueryable<MilitaryVideo> findallvideo()
        {
            return db.MilitaryVideo.OrderByDescending(p => p.MilitaryVideo_id);
        }
        public IList<ForumSection> selectsec()
        {
            return db.ForumSection.ToList();
        }
       public IQueryable<Forum> selectallforum()
        {
            return db.Forum.OrderByDescending(p => p.ForumTime);
        }
       public Forum selectforum(int? id)
        {
            return db.Forum.Single(p => p.Forum_id == id);
        }
       public void Deleteforum(int id)
        {
            Forum forum = db.Forum.Single(o => o.Forum_id == id);
            db.Forum.Remove(forum);
            db.SaveChanges();
        }

       public void Updateforum(Forum forum)
        {
            db.Entry<Forum>(forum).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

       public void AddToforum(Forum forum)
        {
            db.Forum.Add(forum);
            db.SaveChanges();
        }

        //评论回复
       public void AddCommentEssay(CommentForum commforum)
        {
            commforum.CommentTime = DateTime.Now;
            commforum.CommentForumParise = 1;
            db.CommentForum.Add(commforum);
            db.SaveChanges();
        }
       public IQueryable<CommentForum> findallcomment(int? id)
        {
            return db.CommentForum.Where(p => p.Forum_id == id);
        }
       public void UpdateCommend(CommentForum commforum)
        {
            db.Entry<CommentForum>(commforum).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteCommend(int id)
        {
            CommentForum commi = db.CommentForum.Single(p => p.CommentForum_id == id);
            db.CommentForum.Remove(commi);
            db.SaveChanges();
        }
       public void addReplyForum(ReplyForum replyforum)
        {
            replyforum.ReplyTime = DateTime.Now;
            replyforum.ReplyForumParise = 1;
            db.ReplyForum.Add(replyforum);
            db.SaveChanges();
        }
       public IQueryable<ReplyForum> findallreply(int id)
        {
            return db.ReplyForum.Where(p => p.CommentForum_id == id);
        }
       public void UpdateRely(ReplyForum replyforum)
        {
            db.Entry<ReplyForum>(replyforum).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteReply(int id)
        {
            ReplyForum repli = db.ReplyForum.Single(p => p.ReplyForum_id == id);
            db.ReplyForum.Remove(repli);
            db.SaveChanges();
        }
       public int countmiti(int id)
        {
            return db.CommentForum.Count(p => p.Forum_id == id);
        }
      public  int countrep(int id)
        {
            return db.ReplyForum.Count(o => o.CommentForum_id == id);
        }

      public  CommentForum findcommforum(int id)
        {
            return db.CommentForum.Single(p => p.CommentForum_id == id);
        }
       public ReplyForum findreplyforum(int id)
        {
            return db.ReplyForum.Single(o => o.ReplyForum_id == id);
        }


    }
}
