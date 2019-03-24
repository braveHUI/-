using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using IDAL;
using DALFactory;

namespace BLL
{
   public class CommentNewsManage
    {
        public static ICommentNews commentnews = DataAccess.Createcommentnews();
        public static void AddComment(CommentNews commnews)
        {
            commentnews.AddComment(commnews);
        }
        public static IQueryable<CommentNews> FindAllComment(int? id)
        {
            return commentnews.FindAllComment(id);
        }
        public static void UpdateCommend(CommentNews commnews)
        {
            commentnews.UpdateCommend(commnews);
        }
        public static void DeleteCommend(int id)
        {
            commentnews.DeleteCommend(id);
        }
        public static void AddReplyNews(ReplyNews replynew)
        {
            commentnews.AddReplyNews(replynew);
        }
        public static IQueryable<ReplyNews> FindAllReply(int id)
        {
           return commentnews.FindAllReply(id);
        }
        public static void UpdateRely(ReplyNews replynew)
        {
            commentnews.UpdateRely(replynew);
        }
        public static void DeleteReply(int id)
        {
            commentnews.DeleteReply(id);
        }
        public static int Countmiti(int id)
        {
            return commentnews.Countmiti(id);
        }
        public static int Countrep(int id)
        {
            return commentnews.Countrep(id);
        }

        public static CommentNews FindCommNews(int id)
        {
            return commentnews.FindCommNews(id);
        }
        public static ReplyNews FindReplyNews(int id)
        {
            return commentnews.FindReplyNews(id);
        }
    }
}
