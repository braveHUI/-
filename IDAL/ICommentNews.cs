using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface ICommentNews
    {
        void AddComment(CommentNews commnews);
        IQueryable<CommentNews> FindAllComment(int? id);
        void UpdateCommend(CommentNews commnews);
        void DeleteCommend(int id);
        void AddReplyNews(ReplyNews replynew);
        IQueryable<ReplyNews> FindAllReply(int id);
        void UpdateRely(ReplyNews replynew);
        void DeleteReply(int id);
        int Countmiti(int id);
        int Countrep(int id);

        CommentNews FindCommNews(int id);
        ReplyNews FindReplyNews(int id);


    }
}
