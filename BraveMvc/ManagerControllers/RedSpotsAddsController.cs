using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace BraveMvc.ManagerControllers
{
    public class RedSpotsAddsController : Controller
    {
        private BraveEntities db = new BraveEntities();

        // GET: RedSpotsAdds
        public ActionResult Index()
        {
            var redSpots = db.RedSpots.Include(r => r.RedSection);
            return View(redSpots.ToList());
        }

        // GET: RedSpotsAdds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedSpots redSpots = db.RedSpots.Find(id);
            if (redSpots == null)
            {
                return HttpNotFound();
            }
            return View(redSpots);
        }

        // GET: RedSpotsAdds/Create
        public ActionResult Create()
        {
            ViewBag.RedSection_id = new SelectList(db.RedSection, "RedSection_id", "RedSectionName");
            return View();
        }

        // POST: RedSpotsAdds/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RedSpots_id,RedSpotsName,RedSpotsDes,Location,RedSpotsClick,RedImage,RedAbstract,RedArea,RedSection_id")] RedSpots redSpots)
        {
            if (ModelState.IsValid)
            {
                db.RedSpots.Add(redSpots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RedSection_id = new SelectList(db.RedSection, "RedSection_id", "RedSectionName", redSpots.RedSection_id);
            return View(redSpots);
        }

        // GET: RedSpotsAdds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedSpots redSpots = db.RedSpots.Find(id);
            if (redSpots == null)
            {
                return HttpNotFound();
            }
            ViewBag.RedSection_id = new SelectList(db.RedSection, "RedSection_id", "RedSectionName", redSpots.RedSection_id);
            return View(redSpots);
        }

        // POST: RedSpotsAdds/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RedSpots_id,RedSpotsName,RedSpotsDes,Location,RedSpotsClick,RedImage,RedAbstract,RedArea,RedSection_id")] RedSpots redSpots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redSpots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RedSection_id = new SelectList(db.RedSection, "RedSection_id", "RedSectionName", redSpots.RedSection_id);
            return View(redSpots);
        }

        // GET: RedSpotsAdds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedSpots redSpots = db.RedSpots.Find(id);
            if (redSpots == null)
            {
                return HttpNotFound();
            }
            return View(redSpots);
        }

        // POST: RedSpotsAdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RedSpots redSpots = db.RedSpots.Find(id);
            db.RedSpots.Remove(redSpots);
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
