using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DAL;
using DALFactory;

namespace BLL
{
   public class CommentMiliVideoManage
    {
        public static ICommentMiliVideo commmilivide = DataAccess.CreateMiliVideo();
        public static MilitaryVideo getmivideo(int id)
        {
            return commmilivide.getmivideo(id);
        }
        public static void AddCommentMiliVideo(CommendMilitaryVideo commmili)
        {
            commmilivide.AddCommentMiliVideo(commmili);
        }
        public static IQueryable<CommendMilitaryVideo> findallcomment(int id)
        {
            return commmilivide.findallcomment(id);
        }
        public static void UpdateCommend(CommendMilitaryVideo commmili)
        {
            commmilivide.UpdateCommend(commmili);
        }
        public static void DeleteCommend(int id)
        {
            commmilivide.DeleteCommend(id);
        }
        public static void addReplyMiliVideo(ReplyMilitaryVideo replymili)
        {
            commmilivide.addReplyMiliVideo(replymili);
        }
        public static IQueryable<ReplyMilitaryVideo> findallreply(int id)
        {
            return commmilivide.findallreply(id);
        }
        public static void UpdateRely(ReplyMilitaryVideo replymili)
        {
            commmilivide.UpdateRely(replymili);
        }
        public static void DeleteReply(int id)
        {
            commmilivide.DeleteReply(id);
        }
        public static int countmiti(int id)
        {
            return commmilivide.countmiti(id);
        }
        public int countrep(int id)
        {
            return commmilivide.countmiti(id);
        }
        public static void addcommPraise(CommendVideoPaise commpaise)
        {
            commmilivide.addcommPraise(commpaise);
        }
        public static void addrepPraise(ReplyVideoParise reppaise)
        {
            commmilivide.addrepPraise(reppaise);
        }
        public static CommendMilitaryVideo findcommvideo(int id)
        {
            return commmilivide.findcommvideo(id);
        }
        public static ReplyMilitaryVideo findreplyvideo(int id)
        {
            return commmilivide.findreplyvideo(id);
        }
    }
}
