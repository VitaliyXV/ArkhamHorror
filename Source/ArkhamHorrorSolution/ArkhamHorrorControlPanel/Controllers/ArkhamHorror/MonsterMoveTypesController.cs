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
    public class MonsterMoveTypesController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: MonsterMoveTypes
        public ActionResult Index()
        {
            var monsterMoveTypes = db.MonsterMoveTypes.Include(m => m.Color1);
            return View(monsterMoveTypes.ToList());
        }

        // GET: MonsterMoveTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterMoveType monsterMoveType = db.MonsterMoveTypes.Find(id);
            if (monsterMoveType == null)
            {
                return HttpNotFound();
            }
            return View(monsterMoveType);
        }

        // GET: MonsterMoveTypes/Create
        public ActionResult Create()
        {
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName");
            return View();
        }

        // POST: MonsterMoveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Color,Description")] MonsterMoveType monsterMoveType)
        {
            if (ModelState.IsValid)
            {
                db.MonsterMoveTypes.Add(monsterMoveType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName", monsterMoveType.Color);
            return View(monsterMoveType);
        }

        // GET: MonsterMoveTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterMoveType monsterMoveType = db.MonsterMoveTypes.Find(id);
            if (monsterMoveType == null)
            {
                return HttpNotFound();
            }
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName", monsterMoveType.Color);
            return View(monsterMoveType);
        }

        // POST: MonsterMoveTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Color,Description")] MonsterMoveType monsterMoveType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monsterMoveType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName", monsterMoveType.Color);
            return View(monsterMoveType);
        }

        // GET: MonsterMoveTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterMoveType monsterMoveType = db.MonsterMoveTypes.Find(id);
            if (monsterMoveType == null)
            {
                return HttpNotFound();
            }
            return View(monsterMoveType);
        }

        // POST: MonsterMoveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonsterMoveType monsterMoveType = db.MonsterMoveTypes.Find(id);
            db.MonsterMoveTypes.Remove(monsterMoveType);
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
