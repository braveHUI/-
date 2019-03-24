using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using DAL;
using Models;

namespace BLL
{
   public class ForumManage
    {
        public static IForum foru = DataAccess.Createforum();
        public static IQueryable<MilitaryVideo> findallvideo()
        {
            return foru.findallvideo();
        }
        public static IList<ForumSection> selectsec()
        {
            return foru.selectsec();
        }
        public static IQueryable<Forum> selectallforum()
        {
            return  foru.selectallforum();
        }
        public static Forum selectforum(int? id)
        {
            return foru.selectforum(id);
        }
        public static void Deleteforum(int id)
        {
            foru.Deleteforum(id);
        }

        public static void Updateforum(Forum forum)
        {
            foru.Updateforum(forum);
        }

        public static void AddToforum(Forum forum)
        {
            foru.AddToforum(forum);
        }
        //评论回复
        public static void AddCommentEssay(CommentForum commforum)
        {
            foru.AddCommentEssay(commforum);
        }
        public static IQueryable<CommentForum> findallcomment(int? id)
        {
            return foru.findallcomment(id);
        }
        public static void UpdateCommend(CommentForum commforum)
        {
            foru.UpdateCommend(commforum);
        }
        public static void DeleteCommend(int id)
        {
            foru.DeleteCommend(id);
        }
        public static void addReplyForum(ReplyForum replyforum)
        {
            foru.addReplyForum(replyforum);
        }
        public static IQueryable<ReplyForum> findallreply(int id)
        {
            return foru.findallreply(id);
        }
        public static void UpdateRely(ReplyForum replyforum)
        {
            foru.UpdateRely(replyforum);
        }
        public static void DeleteReply(int id)
        {
            foru.DeleteReply(id);
        }
        public static int countmiti(int id)
        {
            return foru.countmiti(id);
        }
        public static int countrep(int id)
        {
            return foru.countrep(id);
        }

        public static CommentForum findcommforum(int id)
        {
            return foru.findcommforum(id);
        }
        public static ReplyForum findreplyforum(int id)
        {
            return foru.findreplyforum(id);
        }
    }
}
