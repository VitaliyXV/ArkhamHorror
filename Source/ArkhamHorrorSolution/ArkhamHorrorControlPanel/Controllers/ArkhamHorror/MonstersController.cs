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
    public class MonstersController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        // GET: Monsters
        public ActionResult Index()
        {
            var monsters = db.Monsters.Include(m => m.Dimension1).Include(m => m.GameExtention1).Include(m => m.MonsterMoveType1).Include(m => m.MonsterType1);
            return View(monsters.ToList());
        }

        // GET: Monsters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster monster = db.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            return View(monster);
        }

        // GET: Monsters/Create
        public ActionResult Create()
        {
            ViewBag.Dimension = new SelectList(db.Dimensions, "Id", "LocalName");
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "LocalName");
            ViewBag.MonsterMoveType = new SelectList(db.MonsterMoveTypes, "Id", "LocalName");
            ViewBag.MonsterType = new SelectList(db.MonsterTypes, "Id", "LocalName");
            return View();
        }

        // POST: Monsters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention,MonsterMoveType,MonsterType,Dimension,Toughness,Awareness,HorrorRating,HorrorDamage,CombatRating,CombatDamage")] Monster monster)
        {
            if (ModelState.IsValid)
            {
                db.Monsters.Add(monster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dimension = new SelectList(db.Dimensions, "Id", "LocalName", monster.Dimension);
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "LocalName", monster.GameExtention);
            ViewBag.MonsterMoveType = new SelectList(db.MonsterMoveTypes, "Id", "LocalName", monster.MonsterMoveType);
            ViewBag.MonsterType = new SelectList(db.MonsterTypes, "Id", "LocalName", monster.MonsterType);
            return View(monster);
        }

        // GET: Monsters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster monster = db.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dimension = new SelectList(db.Dimensions, "Id", "LocalName", monster.Dimension);
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "LocalName", monster.GameExtention);
            ViewBag.MonsterMoveType = new SelectList(db.MonsterMoveTypes, "Id", "LocalName", monster.MonsterMoveType);
            ViewBag.MonsterType = new SelectList(db.MonsterTypes, "Id", "LocalName", monster.MonsterType);
            ViewBag.Abilities = db.Abilities;
            return View(monster);
        }

        // POST: Monsters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OriginalName,LocalName,Description,GameExtention,MonsterMoveType,MonsterType,Dimension,Toughness,Awareness,HorrorRating,HorrorDamage,CombatRating,CombatDamage")] Monster monster, int[] selectedAbilities)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(monster).State = EntityState.Modified;

                var mon = db.Monsters.First(m => m.Id == monster.Id);

                mon.Description = monster.Description;
                mon.GameExtention = monster.GameExtention;
                mon.LocalName = monster.LocalName;
                mon.OriginalName = monster.OriginalName;
                mon.Awareness = monster.Awareness;
                mon.CombatDamage = monster.CombatDamage;
                mon.CombatRating = monster.CombatRating;
                mon.Dimension = monster.Dimension;
                mon.HorrorDamage = monster.HorrorDamage;
                mon.HorrorRating = monster.HorrorRating;
                mon.MonsterMoveType = monster.MonsterMoveType;
                mon.MonsterType = monster.MonsterType;
                mon.Toughness = monster.Toughness;
               
                mon.Abilities.Clear();
                if (selectedAbilities != null)
                {
                    //получаем выбранные свойства
                    foreach (var c in db.Abilities.Where(a => selectedAbilities.Contains(a.Id)))
                    {
                        mon.Abilities.Add(c);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dimension = new SelectList(db.Dimensions, "Id", "LocalName", monster.Dimension);
            ViewBag.GameExtention = new SelectList(db.GameExtentions, "Id", "LocalName", monster.GameExtention);
            ViewBag.MonsterMoveType = new SelectList(db.MonsterMoveTypes, "Id", "LocalName", monster.MonsterMoveType);
            ViewBag.MonsterType = new SelectList(db.MonsterTypes, "Id", "LocalName", monster.MonsterType);
            return View(monster);
        }

        // GET: Monsters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster monster = db.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            return View(monster);
        }

        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monster monster = db.Monsters.Find(id);
            db.Monsters.Remove(monster);
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
