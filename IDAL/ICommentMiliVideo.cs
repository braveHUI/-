using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface ICommentMiliVideo
    {
        MilitaryVideo getmivideo(int id);
        void AddCommentMiliVideo(CommendMilitaryVideo commmili);
        IQueryable<CommendMilitaryVideo> findallcomment(int id);
        void UpdateCommend(CommendMilitaryVideo commmili);
        void DeleteCommend(int id);
        void addReplyMiliVideo(ReplyMilitaryVideo replymili);
        IQueryable<ReplyMilitaryVideo> findallreply(int id);
        void UpdateRely(ReplyMilitaryVideo replymili);
        void DeleteReply(int id);
        int countmiti(int id);
        int countrep(int id);
        void addcommPraise(CommendVideoPaise commpaise);
        void addrepPraise(ReplyVideoParise reppaise);
        CommendMilitaryVideo findcommvideo(int id);
        ReplyMilitaryVideo findreplyvideo(int id);
    }
}
