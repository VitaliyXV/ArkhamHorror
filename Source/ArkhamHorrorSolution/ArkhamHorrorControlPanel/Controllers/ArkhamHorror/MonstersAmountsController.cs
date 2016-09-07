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
    public class MonstersAmountsController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: MonstersAmounts
        public ActionResult Index()
        {
            var monstersAmounts = db.MonstersAmounts.Include(m => m.GameExtention1).Include(m => m.Monster1);
            return View(monstersAmounts.ToList());
        }

        // GET: MonstersAmounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonstersAmount monstersAmount = db.MonstersAmounts.Find(id);
            if (monstersAmount == null)
            {
                return HttpNotFound();
            }
            return View(monstersAmount);
        }

        // GET: MonstersAmounts/Create
        public ActionResult Create()
        {
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName");
            ViewBag.Monster = new SelectList(db.Monsters, "Id", "OriginalName");
            return View();
        }

        // POST: MonstersAmounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Monster,GameExtention,Amount")] MonstersAmount monstersAmount)
        {
            if (ModelState.IsValid)
            {
                db.MonstersAmounts.Add(monstersAmount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", monstersAmount.GameExtention);
            ViewBag.Monster = new SelectList(db.Monsters, "Id", "OriginalName", monstersAmount.Monster);
            return View(monstersAmount);
        }

        // GET: MonstersAmounts/Edit/5
        public ActionResult Edit(int? id, int? idExt)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MonstersAmount monstersAmount = db.MonstersAmounts.FirstOrDefault(m => m.Monster == id && m.GameExtention == idExt);
            if (monstersAmount == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "LocalName", monstersAmount.GameExtention);
            ViewBag.Monster = new SelectList(db.Monsters, "Id", "LocalName", monstersAmount.Monster);
            return View(monstersAmount);
        }

        // POST: MonstersAmounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Monster,GameExtention,Amount")] MonstersAmount monstersAmount)
        {
            if (ModelState.IsValid)
            {
                var ma = db.MonstersAmounts.Find(monstersAmount);
                db.Entry(monstersAmount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", monstersAmount.GameExtention);
            ViewBag.Monster = new SelectList(db.Monsters, "Id", "OriginalName", monstersAmount.Monster);
            return View(monstersAmount);
        }

        // GET: MonstersAmounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonstersAmount monstersAmount = db.MonstersAmounts.Find(id);
            if (monstersAmount == null)
            {
                return HttpNotFound();
            }
            return View(monstersAmount);
        }

        // POST: MonstersAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonstersAmount monstersAmount = db.MonstersAmounts.Find(id);
            db.MonstersAmounts.Remove(monstersAmount);
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
