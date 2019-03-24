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
   public class PostManage
    {
        public static IPost pos = DataAccess.Createpost();
        public static IList<Post> selectallpost()
        {
            return pos.selectallpost();
        }
        public static Post selectpost(int id)
        {
            return pos.selectpost(id);
        }
        public static void Deletepost(int id)
        {
            pos.Deletepost(id);
        }

        public static void Updatepost(Post post)
        {
            pos.Updatepost(post);
        }

        public static void AddTopost(Post post)
        {
            pos.AddTopost(post);
        }
       //军吧
        public static void AddForumsection(ForumSection forumsess)
        {
             pos.AddForumsection(forumsess);
        }
        public static void DeleteForumsection(int id)
        {
            pos.DeleteForumsection(id);
        }

        public static void UpdateForumsection(ForumSection forumsess)
        {

            pos.UpdateForumsection(forumsess);
        }
        public static IEnumerable<ForumSection> selsectallsec()
        {
            return pos.selsectallsec();
        }
        public static IEnumerable<Post> selectzhepost(int id)
        {
            return pos.selectzhepost(id);
        }
        public static ForumSection findforumsec(int id)
        {
            return pos.findforumsec(id);
        }
        //评论回复
        public static void AddCommentPost(CommentPost commPost)
        {
            pos.AddCommentPost(commPost);

        }
        public static IQueryable<CommentPost> findallcomment(int id)
        {
            return pos.findallcomment(id);
        }
        public static void UpdateCommend(CommentPost commpost)
        {
            pos.UpdateCommend(commpost);
        }
        public static void DeleteCommend(int id)
        {
            pos.DeleteCommend(id);
        }
        public static void addReplyPost(ReplyPost replypost)
        {
            pos.addReplyPost(replypost);
        }
        public static IQueryable<ReplyPost> findallreply(int id)
        {
           return pos.findallreply(id);
        }
        public static void UpdateRely(ReplyPost replypost)
        {
            pos.UpdateRely(replypost);
        }
        public static void DeleteReply(int id)
        {
            pos.DeleteReply(id);
        }
        public static int countmiti(int id)
        {
            return pos.countmiti(id);
        }
        public static int countrep(int id)
        {
            return pos.countrep(id);
        }

        public static CommentPost findcommpost(int id)
        {
            return pos.findcommpost(id);
        }
        public static ReplyPost findreplypost(int id)
        {
            return pos.findreplypost(id);
        }

    }
}
