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
    public class SpecialEncountersController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: SpecialEncounters
        public ActionResult Index()
        {
            return View(db.SpecialEncounters.ToList());
        }

        // GET: SpecialEncounters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialEncounter specialEncounter = db.SpecialEncounters.Find(id);
            if (specialEncounter == null)
            {
                return HttpNotFound();
            }
            return View(specialEncounter);
        }

        // GET: SpecialEncounters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialEncounters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description")] SpecialEncounter specialEncounter)
        {
            if (ModelState.IsValid)
            {
                db.SpecialEncounters.Add(specialEncounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialEncounter);
        }

        // GET: SpecialEncounters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialEncounter specialEncounter = db.SpecialEncounters.Find(id);
            if (specialEncounter == null)
            {
                return HttpNotFound();
            }
            return View(specialEncounter);
        }

        // POST: SpecialEncounters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description")] SpecialEncounter specialEncounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialEncounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialEncounter);
        }

        // GET: SpecialEncounters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialEncounter specialEncounter = db.SpecialEncounters.Find(id);
            if (specialEncounter == null)
            {
                return HttpNotFound();
            }
            return View(specialEncounter);
        }

        // POST: SpecialEncounters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialEncounter specialEncounter = db.SpecialEncounters.Find(id);
            db.SpecialEncounters.Remove(specialEncounter);
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
