using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public  class SqlCommentRedSpots:ICommentRedSpots
    {

        BraveEntities db = new BraveEntities();
        public void AddCommentRedSpots(CommentRedSpots comcomredspots)
        {
            db.CommentRedSpots.Add(comcomredspots);
            db.SaveChanges();
        }
        public IList<CommentRedSpots> FindRedCom(int id)
        {
            return db.CommentRedSpots.Include("Users").Where(p => p.RedSpots_id == id).ToList();
        }
        public void addReplyRedSpots(ReplyRedSpots repredspots)
        {
            db.ReplyRedSpots.Add(repredspots);
            db.SaveChanges();
        }
        public IList<ReplyRedSpots> FindRedRep(int id)
        {
            return db.ReplyRedSpots.Include("Users").Where(p => p.CommentRedSpots_id == id).ToList();
        }
    }
}
