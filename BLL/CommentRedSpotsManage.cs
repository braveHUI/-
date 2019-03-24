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
  public  class CommentRedSpotsManage
    {

        public static  ICommentRedSpots commred = DataAccess.CreateCommRedSpots();
        public static void  AddCommentRedSpots(CommentRedSpots comcomredspots)
        {
            commred.AddCommentRedSpots(comcomredspots);
        }
        public static IList<CommentRedSpots> FindRedCom(int id)
        {
            return commred.FindRedCom(id);
        }
        public static void addReplyRedSpots(ReplyRedSpots repredspots)
        {
          commred.addReplyRedSpots(repredspots);
        }
        public static IList<ReplyRedSpots> FindRedRep(int id)
        {
            return commred.FindRedRep(id);
        }
    }
}
