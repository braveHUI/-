using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface IPost
    {
       
        IList<Post> selectallpost();
        Post selectpost(int id);
        void Deletepost(int id);

        void Updatepost(Post post);

        void AddTopost(Post post);
        //增加军吧
        void AddForumsection(ForumSection forumsess);
        void DeleteForumsection(int id);

        void UpdateForumsection(ForumSection forumsess);
        IEnumerable<ForumSection> selsectallsec();
        IEnumerable<Post> selectzhepost(int id);
        ForumSection findforumsec(int id);
       

        //回复评论
        void AddCommentPost(CommentPost commPost);
        IQueryable<CommentPost> findallcomment(int id);
        void UpdateCommend(CommentPost commpost);
        void DeleteCommend(int id);
        void addReplyPost(ReplyPost replypost);
        IQueryable<ReplyPost> findallreply(int id);
        void UpdateRely(ReplyPost replypost);
        void DeleteReply(int id);
        int countmiti(int id);
        int countrep(int id);

        CommentPost findcommpost(int id);
        ReplyPost findreplypost(int id);
    }
}
