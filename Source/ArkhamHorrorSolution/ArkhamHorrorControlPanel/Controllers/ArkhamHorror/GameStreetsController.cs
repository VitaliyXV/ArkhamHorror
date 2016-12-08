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
    public class GameStreetsController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: GameStreets
        public ActionResult Index()
        {
            var gameStreets = db.GameStreets.Include(g => g.GameExtention1);
            return View(gameStreets.ToList());
        }

        // GET: GameStreets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameStreet gameStreet = db.GameStreets.Find(id);
            if (gameStreet == null)
            {
                return HttpNotFound();
            }
            return View(gameStreet);
        }

        // GET: GameStreets/Create
        public ActionResult Create()
        {
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName");
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName");
            return View();
        }

        // POST: GameStreets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention,Color")] GameStreet gameStreet)
        {
            if (ModelState.IsValid)
            {
                db.GameStreets.Add(gameStreet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", gameStreet.GameExtention);
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName", gameStreet.Color);
            return View(gameStreet);
        }

        // GET: GameStreets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameStreet gameStreet = db.GameStreets.Find(id);
            if (gameStreet == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", gameStreet.GameExtention);
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName");
            return View(gameStreet);
        }

        // POST: GameStreets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention")] GameStreet gameStreet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameStreet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", gameStreet.GameExtention);
            ViewBag.Color = new SelectList(db.Colors, "Id", "OriginalName", gameStreet.Color);
            return View(gameStreet);
        }

        // GET: GameStreets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameStreet gameStreet = db.GameStreets.Find(id);
            if (gameStreet == null)
            {
                return HttpNotFound();
            }
            return View(gameStreet);
        }

        // POST: GameStreets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameStreet gameStreet = db.GameStreets.Find(id);
            db.GameStreets.Remove(gameStreet);
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
