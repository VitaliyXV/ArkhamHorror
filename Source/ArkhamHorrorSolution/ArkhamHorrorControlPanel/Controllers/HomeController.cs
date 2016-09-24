using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ArkhamHorrorLibrary.Model;

namespace ArkhamHorrorControlPanel.Controllers
{
    public class HomeController : Controller
    {
        private ArkhamHorrorModel db = new ArkhamHorrorModel();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Colors()
        {
            return Json(db.Colors.Select(c=> new
            {
                Id=c.Id,
                LocalName = c.LocalName,
                OriginalName = c.OriginalName
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Abilities()
        {
            return Json(db.Abilities.Select(a=> new
            {
                Id=a.Id,
                LocalName = a.LocalName,
                OriginalName = a.OriginalName, 
                Description = a.Description                
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Dimensions()
        {
            return Json(db.Dimensions.Select(d=> new
            {
                Id=d.Id,
                LocalName = d.LocalName,
                OriginalName = d.OriginalName, 
                Description = d.Description,
                GameExtention = d.GameExtention,
                Colors = d.Colors.Select(c => c.Id)
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GameExtentions()
        {
            return Json(db.GameExtentions.Select(e=> new
            {
                Id=e.Id,
                LocalName = e.LocalName,
                OriginalName = e.OriginalName, 
                Description = e.Description,
                ReleaseYear = e.ReleaseYear
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Monsters()
        {
            return Json(db.Monsters.Select(m => new
            {
                Id = m.Id,
                LocalName = m.LocalName,
                OriginalName = m.OriginalName,
                Description = m.Description,
                GameExtention = m.GameExtention,
                MonsterMoveType = m.MonsterMoveType,
                MonsterType = m.MonsterType,
                Dimension = m.Dimension,
                Toughness = m.Toughness,
                Awareness = m.Awareness,
                HorrorRating = m.HorrorRating,
                HorrorDamage = m.HorrorDamage,
                CombatRating = m.CombatRating,
                CombatDamage = m.CombatDamage,
                MonstersAbilities = m.MonstersAbilities.Select(a => new { Id = a.Ability, Value = a.Value }),
                MonstersAmounts = m.MonstersAmounts.Select(c => new { Id = c.GameExtention, Value = c.Amount})
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MonsterMoveTypes()
        {
            return Json(db.MonsterMoveTypes.Select(m => new
            {
                Id = m.Id,
                LocalName = m.LocalName,
                OriginalName = m.OriginalName,
                Description = m.Description,
                Color = m.Color
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MonsterTypes()
        {
            return Json(db.MonsterTypes.Select(m => new
            {
                Id = m.Id,
                LocalName = m.LocalName,
                OriginalName = m.OriginalName,
                Description = m.Description
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AncientOnes()
        {
            return Json(db.AncientOnes.Select(m => new
            {
                Id = m.Id,
                LocalName = m.LocalName,
                OriginalName = m.OriginalName,
                Description = m.Description,
                GameExtention = m.GameExtention,
                AncientPower = m.AncientPower,
                Attack = m.Attack,
                CombatRating = m.CombatRating,
                DoomTrack = m.DoomTrack,
                Worshippers = m.Worshippers,
                AncientOnesAbilities = m.AncientOnesAbilities.Select(a => new { Id = a.Ability, Value = a.Value })
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Heralds()
        {
            return Json(db.Heralds.Select(h => new
            {
                Id = h.Id,
                LocalName = h.LocalName,
                OriginalName = h.OriginalName,
                Description = h.Description,
                GameExtention = h.GameExtention
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}