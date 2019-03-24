using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;
using IDAL;
using DALFactory;
using ViewModels;
using System.Net;


namespace BraveMvc.Controllers
{
    public class AllArmsController : Controller
    {

        BraveEntities db = new BraveEntities();
        static int v_id=0, v_id2=0, v_id3=0;
        // GET: AllArms
        public ActionResult Index()
        {






            var ArmSection = ArmsManage.FindAllSection();
            var sectionid = ArmsManage.FindSectionname(1);
            var Armsa1= ArmsManage.FindAllArms().Where(a => a.ArmsSection_id == 1).OrderByDescending(a=>a.Ctime).Take(10);
            var Armsa = ArmsManage.FindAllArms().Where(a => a.ArmsSection_id == 1);
            var ArmsFilterSection = ArmsManage.FindAllFilterSection().Where(a => a.ArmsSection_id == 1).Where(a => a.AFfilter_id == 1);
            var ArmsFilterSection2 = ArmsManage.FindAllFilterSection().Where(a => a.ArmsSection_id == 1).Where(a => a.AFfilter_id == 2);
            var ArmsFilterSection3 = ArmsManage.FindAllFilterSection().Where(a => a.ArmsSection_id == 1).Where(a => a.AFfilter_id == 3);
            





            ViewModels.Armss index = new ViewModels.Armss();

            index.arms1 = Armsa1;
            index.armSection = ArmSection;
            index.arms = Armsa;
            index.aFilterSection = ArmsFilterSection;
            index.aFilterSection2 = ArmsFilterSection2;
            index.aFilterSection3 = ArmsFilterSection3;
            index.armsectionid = sectionid;


           
            return View(index);
        }

        [HttpGet]
        public ActionResult select(int? id, int? id2, int? id3,string search)
        {
            var Armsa = from m in db.Arms.OrderByDescending(p => p.Arms_id)

                        select m;
            //var Armsa = ArmsManage.FindAllArms();
            if (id!=null)
            {
                v_id = (int)id;
               
            }
            if (id2!=null)
            {
                v_id2= (int)id2;                

            }
           if (id3!=null)
            {
               v_id3 = (int)id3;               
            }

            //fhfj
            if (v_id != 0)

            {
                Armsa = Armsa.Where(a => a.BigSection_id == v_id);
            }
           
            if (v_id2 != 0)
            {
                Armsa = Armsa.Where(a => a.BigSection2_id == v_id2);
            }
            if (v_id3 != 0)
            {
                Armsa = Armsa.Where(a => a.BigSection3_id == v_id3);
            }
            if (!String.IsNullOrEmpty(search))
            {
                Armsa = Armsa.Where(a => a.ArmsName.Contains(search)||a.Manu.Contains(search));
            }
            ViewModels.Armss index = new ViewModels.Armss();


          
            index.arms = Armsa;
            return View(index);
        }

       


        [HttpPost]
        //大分类异步获取id
        public ActionResult Armsid(int id)
        {
            v_id = 0;
            v_id2 = 0;
            v_id3 = 0;
            var sectionid = ArmsManage.FindSectionname(id);
            var ArmSection = ArmsManage.FindAllSection();
            var Armsa1 = ArmsManage.FindAllArms().Where(a => a.ArmsSection_id == id).OrderByDescending(a => a.Ctime).Take(10);
            var Armsa = ArmsManage.FindAllArms().Where(b => b.ArmsSection_id == id);
            var ArmsFilterSection = ArmsManage.FindAllFilterSection().Where(g => g.ArmsSection_id == id).Where(g => g.AFfilter_id == 1);//获取id 找出父类id为此的值.Where(g => g.AFfilter_id == 1)
            var ArmsFilterSection2 = ArmsManage.FindAllFilterSection().Where(a => a.ArmsSection_id == id).Where(a => a.AFfilter_id == 2);
            var ArmsFilterSection3 = ArmsManage.FindAllFilterSection().Where(c => c.ArmsSection_id == id).Where(c => c.AFfilter_id == 3);

            ViewModels.Armss index1 = new ViewModels.Armss();
            index1.armSection = ArmSection;
            index1.arms = Armsa;
            index1.aFilterSection = ArmsFilterSection;
            index1.aFilterSection2 = ArmsFilterSection2;
            index1.aFilterSection3 = ArmsFilterSection3;
            index1.armsectionid = sectionid;
            index1.arms1 = Armsa1;


        

            return View("Armsid", index1);

        }

        public ActionResult Details(int id)
        {

            var armsde1 = ArmsManage.FindArmsId(id);
            if (armsde1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



          
            //var comment_food = from m in db.Comment_Food.Where(p => p.Food_id == id).OrderByDescending(p => p.Addtime) select m;

          



            ViewModels.Armss index = new ViewModels.Armss()
            {

               armsde = armsde1,
               

            };
            return View(index);
        }

    }
}

//public ActionResult Armsid(String sdsd, int? id, int? id2, int? id3)
//{



//    if (id < 0)
//    {
//        id = null;
//    }
//    if (id2 < 0)
//    {
//        id2 = null;
//    }
//    if (id3 < 0)
//    {
//        id3 = null;
//    }
//    var Armsa = ArmsManage.FindAllArms().Where(b => b.BigSection_id == id).Where(b => b.BigSection_id == id2).Where(b => b.BigSection_id == id3);

//    ViewModels.Armss index1 = new ViewModels.Armss();

//    index1.arms = Armsa;
//    return View(index1);





//}

