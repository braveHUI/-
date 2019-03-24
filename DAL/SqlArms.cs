using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public  class SqlArms:IArms
    {

        BraveEntities db = new BraveEntities();

        public IEnumerable<ArmsSection> FindAllSection()
        {
           
            return db.ArmsSection.ToList();
        }
        public ArmsSection FindSectionname(int id)
        {

            return db.ArmsSection.Single(p=>p.ArmsSection_id==id);
        }
        public IEnumerable<Arms> FindAllArms()
        {
            return db.Arms.ToList();
        }
        public IEnumerable<AFilterSection> FindAllFilterSection()
        { 
           
            return db.AFilterSection.ToList();
        }
        //public IEnumerable<Arms> findarms()
        //{
        //    var Armsa = from m in db.Arms.OrderByDescending(p => p.Arms_id)

        //                select m;
        //    return Armsa;
        //}
        public Arms FindArmsId(int id)
        {

            //var userInfo = from s in Arms
            //               join c in AFilterSection s.BigSetion_id equals c.AFilterSection_id
            //                where s.id = id
            //               select new{s.id,c.classid,c.classname }
            return db.Arms.Single(p => p.Arms_id == id);
        }
    }
}
