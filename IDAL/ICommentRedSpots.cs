using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public  interface ICommentRedSpots
    {
        void AddCommentRedSpots(CommentRedSpots comcomredspots);
        IList<CommentRedSpots>FindRedCom(int id);
        void addReplyRedSpots( ReplyRedSpots repredspots);
        IList<ReplyRedSpots> FindRedRep(int id);

    }
}
