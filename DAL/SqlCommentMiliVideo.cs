using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlCommentMiliVideo:ICommentMiliVideo
    {
        BraveEntities db = new BraveEntities();
        public MilitaryVideo getmivideo(int id)
        {
            return db.MilitaryVideo.Single(p => p.MilitaryVideo_id == id);
        }
       public void AddCommentMiliVideo(CommendMilitaryVideo commmili)
        {
            commmili.CommendMilitaryVideoTime = DateTime.Now;

            db.CommendMilitaryVideo.Add(commmili);
            db.SaveChanges();
        }
       public IQueryable<CommendMilitaryVideo> findallcomment(int id)
        {
            return db.CommendMilitaryVideo.Where(l => l.MilitaryVideo_id == id);
        }
       public void UpdateCommend(CommendMilitaryVideo commmili)
        {
            db.Entry<CommendMilitaryVideo>(commmili).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteCommend(int id)
        {
            CommendMilitaryVideo commi = db.CommendMilitaryVideo.Single(p => p.CommendMilitaryVideo_id == id);
            db.CommendMilitaryVideo.Remove(commi);
            db.SaveChanges();
        }
       public void addReplyMiliVideo(ReplyMilitaryVideo replymili)
        {
            replymili.ReplyMilitaryVideoTime = DateTime.Now;
            db.ReplyMilitaryVideo.Add(replymili);
            db.SaveChanges();
        }
       public IQueryable<ReplyMilitaryVideo> findallreply(int id)
        {
            return db.ReplyMilitaryVideo.Where(p => p.CommentMilitaryVideo_id == id);
        }
       public void UpdateRely(ReplyMilitaryVideo replymili)
        {
            db.Entry<ReplyMilitaryVideo>(replymili).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       public void DeleteReply(int id)
        {
            ReplyMilitaryVideo rep = db.ReplyMilitaryVideo.Single(o => o.ReplyMilitaryVideo_id == id);
            db.ReplyMilitaryVideo.Remove(rep);
            db.SaveChanges();
        }
       public int countmiti(int id)
        {
            return db.CommendMilitaryVideo.Count(p => p.MilitaryVideo_id == id);
        }
      public int countrep(int id)
        {
            return db.ReplyMilitaryVideo.Count(o => o.CommentMilitaryVideo_id == id);
        }
       public void addcommPraise(CommendVideoPaise commpaise)
        {
            db.CommendVideoPaise.Add(commpaise);
            db.SaveChanges();
        }
       public void addrepPraise(ReplyVideoParise reppaise)
        {
            db.ReplyVideoParise.Add(reppaise);
            db.SaveChanges();
        }
       public CommendMilitaryVideo findcommvideo(int id)
        {
            return db.CommendMilitaryVideo.Single(p => p.CommendMilitaryVideo_id == id);
        }
       public ReplyMilitaryVideo findreplyvideo(int id)
        {
            return db.ReplyMilitaryVideo.Single(o => o.ReplyMilitaryVideo_id == id);
        }
    }
}
