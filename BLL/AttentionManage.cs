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
   public class AttentionManage
    {
        public static IAttention aatew = DataAccess.CreateAttention();
        public static void Addatten(Attention attention)
        {
            aatew.Addatten(attention);

        }
        public static void deleteadd(int id)
        {
            aatew.deleteadd(id);

        }
        public static Attention selecatten(int userid, int buserid)
        {
            return aatew.selecatten(userid, buserid);
        }
        public static IQueryable<Attention> selectallatten(int userid)
        {
            return aatew.selectallatten(userid);
        }
        public static IQueryable<Attention> selectbatten(int buserid)
        {
            return aatew.selectbatten(buserid);
        }
       public static void Addcollection(Collection collection)
        {
            aatew.Addcollection(collection);
        }
      public static void deletecoll(int id)
        {
            aatew.deletecoll(id);
        }
        //军吧关注   
        public static void Addattenpost(AttentionPost attention)
        {
            aatew.Addattenpost(attention);
        }
        public static void deleteaddpost(int id)
        {
            aatew.deleteaddpost(id);
        }
        public static AttentionPost selectattenpostforu(int userid, int forumsecid)
        {
            return aatew.selectattenpostforu(userid, forumsecid);
        }
        public static IQueryable<AttentionPost> selectattenpost(int userid)
        {
            return aatew.selectattenpost(userid);
        }
        public static IQueryable<AttentionPost> selectattpostforu(int forumsecid)
        {
            return aatew.selectattpostforu(forumsecid);
        }
        public static int findattenjisuan(int forumsecid)
        {
            return aatew.findattenjisuan(forumsecid);
        }
        public static int findallpost(int forumsecid)
        {
            return aatew.findallpost(forumsecid);
        }
        //签到
        public static void AddSign(Signature singtr)
        {

            aatew.AddSign(singtr);
        }
        public static Signature findsign(int userid, int forumid)
        {
            return aatew.findsign(userid, forumid);
        }
        public static Collection selectcollec(int userid, int? forumid)
        {
            return aatew.selectcollec(userid, forumid);
        }
       public static IQueryable<Collection> selectallcollec(int userid)
        {
            return aatew.selectallcollec(userid);
        }
    }
}
