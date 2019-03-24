using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlCommunication : ICommunication
    {
        BraveEntities db = new BraveEntities();
        public void AddCommenication(Communication communication)
        {

            communication.CommunicationTime = DateTime.Now;
            communication.Flag = false;
            db.Communication.Add(communication);
            db.SaveChanges();

        }
        public void DeleteCommenication(int id)
        {
            var sdeq = db.Communication.Single(p => p.Communication_id == id);
            db.Communication.Remove(sdeq);
            db.SaveChanges();
        }
        public IEnumerable<Communication> SelectCommenicatio(int ruserid)
        {
            return db.Communication.Where(p => p.RUser_id == ruserid).OrderByDescending(o => o.CommunicationTime);
        }
        public IEnumerable<Communication> SelectNocommication(int ruserid)
        {
            return db.Communication.Where(p => p.RUser_id == ruserid).Where(o => o.Flag == false).OrderByDescending(n => n.CommunicationTime);
        }
        public IEnumerable<Communication> SelectMessage(int userid, int? ruserid)
        {

            return db.Communication.Where(p => p.User_id == userid).Where(o => o.RUser_id == ruserid).OrderBy(n => n.CommunicationTime);
        }
        public Communication FindComm(int id)
        {
            return db.Communication.Single(p => p.Communication_id == id);
        }
        public void UpdateCommun(Communication communica)
        {
            db.Entry<Communication>(communica).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
