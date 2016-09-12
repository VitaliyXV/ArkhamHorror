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
    public class AncientOnesController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: AncientOnes
        public ActionResult Index()
        {
            var ancientOnes = db.AncientOnes.Include(a => a.GameExtention1);
            return View(ancientOnes.ToList());
        }

        // GET: AncientOnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AncientOne ancientOne = db.AncientOnes.Find(id);
            if (ancientOne == null)
            {
                return HttpNotFound();
            }
            return View(ancientOne);
        }

        // GET: AncientOnes/Create
        public ActionResult Create()
        {
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName");
            return View();
        }

        // POST: AncientOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention,Worshippers,AncientPower,Attack,CombatRating,DoomTrack")] AncientOne ancientOne)
        {
            if (ModelState.IsValid)
            {
                db.AncientOnes.Add(ancientOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", ancientOne.GameExtention);
            return View(ancientOne);
        }

        // GET: AncientOnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AncientOne ancientOne = db.AncientOnes.Find(id);
            if (ancientOne == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", ancientOne.GameExtention);

            var abilities = new List<MonstersController.CurrentAbility>();
            foreach (var abil in db.Abilities)
            {
                var ab = ancientOne.AncientOnesAbilities.FirstOrDefault(a => a.Ability == abil.Id);
                abilities.Add(new MonstersController.CurrentAbility() { Ability = abil, IsEnabled = ab != null, Value = ab == null ? 0 : ab.Value });
            }

            ViewBag.Abilities = abilities;

            return View(ancientOne);
        }

        // POST: AncientOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention,Worshippers,AncientPower,Attack,CombatRating,DoomTrack")] AncientOne ancientOne,
            List<MonstersController.CurrentAbility> selectedAbilities)
        {
           // if (ModelState.IsValid)
            {
                //db.Entry(ancientOne).State = EntityState.Modified;

                var mon = db.AncientOnes.First(m => m.Id == ancientOne.Id);

                mon.Description = ancientOne.Description;
                mon.GameExtention = ancientOne.GameExtention;
                mon.LocalName = ancientOne.LocalName;
                mon.OriginalName = ancientOne.OriginalName;
                mon.AncientPower = ancientOne.AncientPower;
                mon.Attack = ancientOne.Attack;
                mon.CombatRating = ancientOne.CombatRating;
                mon.DoomTrack = ancientOne.DoomTrack;
                mon.Worshippers = ancientOne.Worshippers;

                mon.AncientOnesAbilities.Clear();
                foreach (var a in selectedAbilities.Where(a => a.Ability != null))
                {
                    mon.AncientOnesAbilities.Add(new AncientOnesAbility()
                    {
                        Ability = a.Ability.Id,
                        AncientOne = ancientOne.Id,
                        Value = a.Value
                    });
                }


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "OriginalName", ancientOne.GameExtention);
            return View(ancientOne);
        }

        // GET: AncientOnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AncientOne ancientOne = db.AncientOnes.Find(id);
            if (ancientOne == null)
            {
                return HttpNotFound();
            }
            return View(ancientOne);
        }

        // POST: AncientOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AncientOne ancientOne = db.AncientOnes.Find(id);
            db.AncientOnes.Remove(ancientOne);
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
