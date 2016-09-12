using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArkhamHorrorLibrary.Model;

namespace ArkhamHorrorControlPanel.Controllers.ArkhamHorror
{
    public class HeraldsController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: Heralds
        public ActionResult Index()
        {
            var heralds = db.Heralds.Include(h => h.GameExtention1);
            return View(heralds.ToList());
        }

        // GET: Heralds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herald herald = db.Heralds.Find(id);
            if (herald == null)
            {
                return HttpNotFound();
            }
            return View(herald);
        }

        // GET: Heralds/Create
        public ActionResult Create()
        {
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName");
            return View();
        }

        // POST: Heralds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention")] Herald herald)
        {
            if (ModelState.IsValid)
            {
                db.Heralds.Add(herald);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", herald.GameExtention);
            return View(herald);
        }

        // GET: Heralds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herald herald = db.Heralds.Find(id);
            if (herald == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", herald.GameExtention);
            return View(herald);
        }

        // POST: Heralds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention")] Herald herald)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herald).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", herald.GameExtention);
            return View(herald);
        }

        // GET: Heralds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herald herald = db.Heralds.Find(id);
            if (herald == null)
            {
                return HttpNotFound();
            }
            return View(herald);
        }

        // POST: Heralds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herald herald = db.Heralds.Find(id);
            db.Heralds.Remove(herald);
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
