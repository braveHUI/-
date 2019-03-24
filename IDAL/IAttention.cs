using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface IAttention
    {
        void Addatten(Attention attention);
        void deleteadd(int id);
        Attention selecatten(int userid,int buserid);
        IQueryable<Attention> selectallatten(int userid);
        IQueryable<Attention> selectbatten(int buserid);
      
        //军吧关注
        void Addattenpost(AttentionPost attention);
        void deleteaddpost(int id);
        AttentionPost selectattenpostforu(int userid, int forumsecid);
        IQueryable<AttentionPost> selectattenpost(int userid);
        IQueryable<AttentionPost> selectattpostforu(int forumsecid);
        int findattenjisuan(int forumsecid);
        int findallpost(int forumsecid);
        //签到
        void AddSign(Signature singtr);
        Signature findsign(int userid, int forumid);

        //收藏
        void Addcollection(Collection collection);
        void deletecoll(int id);
        Collection selectcollec(int userid, int? forumid);
        IQueryable<Collection> selectallcollec(int userid);
        

    }
}
