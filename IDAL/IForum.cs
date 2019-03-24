using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface IForum
    {
        IQueryable<MilitaryVideo> findallvideo();
        IList<ForumSection> selectsec();
        IQueryable<Forum> selectallforum();
        Forum selectforum(int? id);
        void Deleteforum(int id);

        void Updateforum(Forum forum);

        void AddToforum(Forum forum);
       //回复评论
        void AddCommentEssay(CommentForum commforum);
        IQueryable<CommentForum> findallcomment(int? id);
        void UpdateCommend(CommentForum commforum);
        void DeleteCommend(int id);
        void addReplyForum(ReplyForum replyforum);
        IQueryable<ReplyForum> findallreply(int id);
        void UpdateRely(ReplyForum replyforum);
        void DeleteReply(int id);
        int countmiti(int id);
        int countrep(int id);
        
        CommentForum findcommforum(int id);
        ReplyForum findreplyforum(int id);
    }
}
