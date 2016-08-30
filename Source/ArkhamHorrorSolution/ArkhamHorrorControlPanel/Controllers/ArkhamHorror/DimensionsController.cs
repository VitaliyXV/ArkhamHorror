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
    public class DimensionsController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: Dimensions
        public ActionResult Index()
        {
            var dimensions = db.Dimensions.Include(d => d.GameExtention1);
            return View(dimensions.ToList());
        }

        // GET: Dimensions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimension dimension = db.Dimensions.Find(id);
            if (dimension == null)
            {
                return HttpNotFound();
            }
            return View(dimension);
        }

        // GET: Dimensions/Create
        public ActionResult Create()
        {
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName");
            return View();
        }

        // POST: Dimensions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention")] Dimension dimension)
        {
            if (ModelState.IsValid)
            {
                db.Dimensions.Add(dimension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", dimension.GameExtention);
            return View(dimension);
        }

        // GET: Dimensions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimension dimension = db.Dimensions.Find(id);
            if (dimension == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", dimension.GameExtention);
            ViewBag.Colors = db.Colors;  //new SelectList(db.Colors, "Id", "OriginalName", dimension.Colors);
            return View(dimension);
        }

        // POST: Dimensions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention")] Dimension dimension, int[] selectedColors)
        {
            if (ModelState.IsValid)
            {
                var dim = db.Dimensions.First(d => d.Id == dimension.Id);

                dim.Description = dimension.Description;
                dim.GameExtention = dimension.GameExtention;
                dim.LocalName = dimension.LocalName;
                dim.OriginalName = dim.OriginalName;

                dim.Colors.Clear();
                if (selectedColors != null)
                {
                    //получаем выбранные цвета
                    foreach (var c in db.Colors.Where(co => selectedColors.Contains(co.Id)))
                    {
                        dim.Colors.Add(c);
                    }
                }

                //db.Entry(dimension).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", dimension.GameExtention);
            return View(dimension);
        }

        // GET: Dimensions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimension dimension = db.Dimensions.Find(id);
            if (dimension == null)
            {
                return HttpNotFound();
            }
            return View(dimension);
        }

        // POST: Dimensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dimension dimension = db.Dimensions.Find(id);
            db.Dimensions.Remove(dimension);
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
