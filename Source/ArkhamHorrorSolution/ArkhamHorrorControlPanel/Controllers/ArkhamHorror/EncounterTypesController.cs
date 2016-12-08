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
    public class EncounterTypesController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: EncounterTypes
        public ActionResult Index()
        {
            return View(db.EncounterTypes.ToList());
        }

        // GET: EncounterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncounterType encounterType = db.EncounterTypes.Find(id);
            if (encounterType == null)
            {
                return HttpNotFound();
            }
            return View(encounterType);
        }

        // GET: EncounterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncounterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description")] EncounterType encounterType)
        {
            if (ModelState.IsValid)
            {
                db.EncounterTypes.Add(encounterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encounterType);
        }

        // GET: EncounterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncounterType encounterType = db.EncounterTypes.Find(id);
            if (encounterType == null)
            {
                return HttpNotFound();
            }
            return View(encounterType);
        }

        // POST: EncounterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description")] EncounterType encounterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encounterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encounterType);
        }

        // GET: EncounterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncounterType encounterType = db.EncounterTypes.Find(id);
            if (encounterType == null)
            {
                return HttpNotFound();
            }
            return View(encounterType);
        }

        // POST: EncounterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncounterType encounterType = db.EncounterTypes.Find(id);
            db.EncounterTypes.Remove(encounterType);
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
