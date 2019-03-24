using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface ICommunication
    {
        void AddCommenication(Communication communication);
        void DeleteCommenication(int id);
        IEnumerable<Communication> SelectCommenicatio(int ruserid);
        IEnumerable<Communication> SelectNocommication(int ruserid);
        IEnumerable<Communication> SelectMessage(int userid, int? ruserid);
        Communication FindComm(int id);
        void UpdateCommun(Communication communica);


    }
}
