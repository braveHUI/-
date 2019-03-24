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
    public class CommunicationManage
    {
        public static ICommunication commu = DataAccess.Createcommution();
        public static void AddCommenication(Communication communication)
        {

            commu.AddCommenication(communication);

        }
        public static void DeleteCommenication(int id)
        {
            commu.DeleteCommenication(id);
        }
        public static IEnumerable<Communication> SelectCommenicatio(int ruserid)
        {
            return commu.SelectCommenicatio(ruserid);
        }
        public static IEnumerable<Communication> SelectNocommication(int ruserid)
        {
            return commu.SelectNocommication(ruserid);
        }
        public static IEnumerable<Communication> SelectMessage(int userid, int? ruserid)
        {
            return commu.SelectMessage(userid, ruserid);
        }
        public static Communication FindComm(int id)
        {
            return commu.FindComm(id);
        }
        public static void UpdateCommun(Communication communica)
        {
            commu.UpdateCommun(communica);
        }
    }
}
