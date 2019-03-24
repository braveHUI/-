using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlAttention: IAttention
    {
        BraveEntities db = new BraveEntities();
        public void Addatten(Attention attention)
        {
            attention.AttentionTime = DateTime.Now;
            db.Attention.Add(attention);
            db.SaveChanges();

        }
       public void deleteadd(int id)
        {
            var sde = db.Attention.Single(p => p.Attention_id == id);
            db.Attention.Remove(sde);
            db.SaveChanges();

        }
       public Attention selecatten(int userid, int buserid)
        {
            return db.Attention.Where(p => p.User_id == userid).Where(o => o.BUser_id == buserid).FirstOrDefault();
        }
       public IQueryable<Attention> selectallatten(int userid)
        {
            return db.Attention.Where(p => p.User_id == userid);
        }
       public IQueryable<Attention> selectbatten(int buserid)
        {
            return db.Attention.Where(o => o.BUser_id == buserid);
        }

        //军吧关注
       public void Addattenpost(AttentionPost attention)
        {
            attention.AttentionTime = DateTime.Now;
            db.AttentionPost.Add(attention);
            db.SaveChanges();
        }
       public void deleteaddpost(int id)
        {
            var sde = db.AttentionPost.Single(p => p.AttentionPost_id == id);
            db.AttentionPost.Remove(sde);
            db.SaveChanges();
        }
       public AttentionPost selectattenpostforu(int userid, int forumsecid)
        {
            return db.AttentionPost.Where(p => p.User_id == userid).Where(o => o.ForumSection_id == forumsecid).FirstOrDefault();
        }
       public IQueryable<AttentionPost> selectattenpost(int userid)
        {
            return db.AttentionPost.Where(p => p.User_id == userid);
        }
       public IQueryable<AttentionPost> selectattpostforu(int forumsecid)
        {
            return db.AttentionPost.Where(p => p.ForumSection_id == forumsecid);
        }
       public int findattenjisuan(int forumsecid)
        {
            return db.AttentionPost.Where(p => p.ForumSection_id == forumsecid).Count();
        }
       public int findallpost(int forumsecid)
        {
            return db.Post.Where(p => p.ForumSection_id == forumsecid).Count();
        }
        //签到
       public void AddSign(Signature singtr)
        {

            singtr.SignatureTime = DateTime.Now;
            db.Signature.Add(singtr);
            db.SaveChanges();
        }
       public Signature findsign(int userid, int forumid)
        {
            return db.Signature.Where(p => p.User_id == userid).Where(o => o.ForumSection_id == forumid).OrderByDescending(l=>l.SignatureTime).FirstOrDefault();
        }
        //收藏
        public void Addcollection(Collection collection)
        {
            collection.CollectorTime = DateTime.Now;
            db.Collection.Add(collection);
            db.SaveChanges();
        }
       public void deletecoll(int id)
        {
            var sdedw = db.Collection.Single(p => p.Collector_id == id);
            db.Collection.Remove(sdedw);
            db.SaveChanges();
        }
       public Collection selectcollec(int userid, int? forumid)
        {
            return db.Collection.Where(p => p.User_id == userid).Where(o => o.Forum_id == forumid).FirstOrDefault();

        }
       public IQueryable<Collection> selectallcollec(int userid)
        {
            return db.Collection.Where(p => p.User_id == userid);
        }
    }
}
