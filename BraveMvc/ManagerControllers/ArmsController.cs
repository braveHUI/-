using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace BraveMvc.ManagerControllers
{
    public class ArmsController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: Arms
        public ActionResult Index()
        {
            var arms = db.Arms.Include(a => a.ArmsSection);
            return View(arms.ToList());
        }

        // GET: Arms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arms arms = db.Arms.Find(id);
            if (arms == null)
            {
                return HttpNotFound();
            }
            return View(arms);
        }

        // GET: Arms/Create
        public ActionResult Create()
        {
           

           

            ViewBag.ArmsSection_id = new SelectList(db.ArmsSection, "ArmsSection_id", "ArmsSectionName");
            //SelectList Gender= new SelectList(db.AFilterSection, "AFilterSection_id", "AFilterSectionName");
            //  ViewBag.Gender = Gender.AsEnumerable();
            //找到表AFilterSection的值并保存
            return View();
        }
        public JsonResult GETAFilter(int id)
        {
         var ListAf = BraveManage.GetAFilterId(id);//获取id 找出父类id为此的值
            return Json(ListAf, JsonRequestBehavior.AllowGet);

        }
       

        // POST: Arms/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Arms_id,ArmsName,ArmsPicture,ArmsVideo,ArmsDes,ArmsSection_id,ArmsTechnical,BigSection_id,BigSection2_id,BigSection3_id,Manu,Stime,Ctime")] Arms arms)
        {
           
            if (ModelState.IsValid)
            {  
                db.Arms.Add(arms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArmsSection_id = new SelectList(db.ArmsSection, "ArmsSection_id", "ArmsSectionName", arms.ArmsSection_id);
         
            return View(arms);
        }

        // GET: Arms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arms arms = db.Arms.Find(id);
            if (arms == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArmsSection_id = new SelectList(db.ArmsSection, "ArmsSection_id", "ArmsSectionName", arms.ArmsSection_id);
            return View(arms);
        }

        // POST: Arms/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Arms_id,ArmsName,ArmsPicture,ArmsVideo,ArmsDes,ArmsSection_id,ArmsTechnical,BigSection_id,BigSection2_id,BigSection3_id,Manu,Stime,Ctime")] Arms arms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArmsSection_id = new SelectList(db.ArmsSection, "ArmsSection_id", "ArmsSectionName", arms.ArmsSection_id);
            return View(arms);
        }

        // GET: Arms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arms arms = db.Arms.Find(id);
            if (arms == null)
            {
                return HttpNotFound();
            }
            return View(arms);
        }

        // POST: Arms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arms arms = db.Arms.Find(id);
            db.Arms.Remove(arms);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
