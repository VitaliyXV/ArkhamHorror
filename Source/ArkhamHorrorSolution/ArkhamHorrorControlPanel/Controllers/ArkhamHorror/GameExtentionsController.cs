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
    public class GameExtentionsController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: GameExtentions
        public ActionResult Index()
        {
            return View(db.GameExtentions.ToList());
        }

        // GET: GameExtentions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameExtention gameExtention = db.GameExtentions.Find(id);
            if (gameExtention == null)
            {
                return HttpNotFound();
            }
            return View(gameExtention);
        }

        // GET: GameExtentions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameExtentions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description,ReleaseYear")] GameExtention gameExtention)
        {
            if (ModelState.IsValid)
            {
                db.GameExtentions.Add(gameExtention);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameExtention);
        }

        // GET: GameExtentions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameExtention gameExtention = db.GameExtentions.Find(id);
            if (gameExtention == null)
            {
                return HttpNotFound();
            }
            return View(gameExtention);
        }

        // POST: GameExtentions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description,ReleaseYear")] GameExtention gameExtention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameExtention).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameExtention);
        }

        // GET: GameExtentions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameExtention gameExtention = db.GameExtentions.Find(id);
            if (gameExtention == null)
            {
                return HttpNotFound();
            }
            return View(gameExtention);
        }

        // POST: GameExtentions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameExtention gameExtention = db.GameExtentions.Find(id);
            db.GameExtentions.Remove(gameExtention);
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
