using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlPost:IPost
    {
        BraveEntities db = new BraveEntities();
        public IList<Post> selectallpost()
        {
            return db.Post.ToList();
        }
       public Post selectpost(int id)
        {
            return db.Post.Single(p => p.Post_id == id);
        }
       public void Deletepost(int id)
        {
            Post post = db.Post.Single(o => o.Post_id == id);
            db.Post.Remove(post);
            db.SaveChanges();
        }

       public void Updatepost(Post post)
        {
            db.Entry<Post>(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

       public void AddTopost(Post post)
        {
            db.Post.Add(post);
            db.SaveChanges();
        }

        //增加军吧
       public void AddForumsection(ForumSection forumsess)
        {
            forumsess.ForumSectionTime = DateTime.Now;
            db.ForumSection.Add(forumsess);
            db.SaveChanges();
        }
       public void DeleteForumsection(int id)
        {
            var sde = db.ForumSection.Single(p => p.ForumSection_id == id);
            db.ForumSection.Remove(sde);
            db.SaveChanges();
        }

       public void UpdateForumsection(ForumSection forumsess)
        {

            db.Entry<ForumSection>(forumsess).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public IEnumerable<ForumSection> selsectallsec()
        {
            return db.ForumSection;
        }
       public IEnumerable<Post> selectzhepost(int id)
        {
            return db.Post.Where(p => p.ForumSection_id == id);
        }
       public ForumSection findforumsec(int id)
        {
            return db.ForumSection.Single(p => p.ForumSection_id == id);
        }
        //评论回复
        public void AddCommentPost(CommentPost commPost)
        {
            commPost.CommentTime = DateTime.Now;
            commPost.CommentPraise = 1;
            db.CommentPost.Add(commPost);
            db.SaveChanges();

        }
       public IQueryable<CommentPost> findallcomment(int id)
        {
            return db.CommentPost.Where(p => p.Post_id == id);
        }
       public void UpdateCommend(CommentPost commpost)
        {
            db.Entry<CommentPost>(commpost).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteCommend(int id)
        {
            CommentPost commi = db.CommentPost.Single(p => p.CommentPost_id == id);
            db.CommentPost.Remove(commi);
            db.SaveChanges();
        }
       public void addReplyPost(ReplyPost replypost)
        {
            replypost.ReplyTime = DateTime.Now;
            replypost.ReplyPraise = 1;
            db.ReplyPost.Add(replypost);
            db.SaveChanges();
        }
      public  IQueryable<ReplyPost> findallreply(int id)
        {
            return db.ReplyPost.Where(p => p.CommentPost_id == id);
        }
       public void UpdateRely(ReplyPost replypost)
        {
            db.Entry<ReplyPost>(replypost).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteReply(int id)
        {
            ReplyPost repli = db.ReplyPost.Single(p => p.ReplyPost_id == id);
            db.ReplyPost.Remove(repli);
            db.SaveChanges();
        }
      public  int countmiti(int id)
        {
            return db.CommentPost.Count(p => p.Post_id == id);
        }
       public int countrep(int id)
        {
            return db.ReplyPost.Count(o => o.CommentPost_id == id);
        }

       public CommentPost findcommpost(int id)
        {
            return db.CommentPost.Single(p => p.CommentPost_id == id);
        }
       public ReplyPost findreplypost(int id)
        {
            return db.ReplyPost.Single(o => o.ReplyPost_id == id);
        }
    }
}
