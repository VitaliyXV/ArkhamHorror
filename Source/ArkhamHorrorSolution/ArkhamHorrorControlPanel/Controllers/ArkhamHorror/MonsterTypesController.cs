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
    public class MonsterTypesController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: MonsterTypes
        public ActionResult Index()
        {
            return View(db.MonsterTypes.ToList());
        }

        // GET: MonsterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterType monsterType = db.MonsterTypes.Find(id);
            if (monsterType == null)
            {
                return HttpNotFound();
            }
            return View(monsterType);
        }

        // GET: MonsterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonsterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description")] MonsterType monsterType)
        {
            if (ModelState.IsValid)
            {
                db.MonsterTypes.Add(monsterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monsterType);
        }

        // GET: MonsterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterType monsterType = db.MonsterTypes.Find(id);
            if (monsterType == null)
            {
                return HttpNotFound();
            }
            return View(monsterType);
        }

        // POST: MonsterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description")] MonsterType monsterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monsterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monsterType);
        }

        // GET: MonsterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterType monsterType = db.MonsterTypes.Find(id);
            if (monsterType == null)
            {
                return HttpNotFound();
            }
            return View(monsterType);
        }

        // POST: MonsterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonsterType monsterType = db.MonsterTypes.Find(id);
            db.MonsterTypes.Remove(monsterType);
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
