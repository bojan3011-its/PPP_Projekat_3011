using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bojan3011_ppp_projekat.Models;

namespace bojan3011_ppp_projekat.Controllers
{
    public class NalogsController : Controller
    {
        private RentacarDBContext db = new RentacarDBContext();

        // GET: Nalogs
        public ActionResult Index()
        {
            var nalogs = db.Nalogs.Include(n => n.Klijent).Include(n => n.Vozilo);
            return View(nalogs.ToList());
        }

        // GET: Nalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalogs.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // GET: Nalogs/Create
        public ActionResult Create()
        {
            ViewBag.KlijentID = new SelectList(db.Klijents, "KlijentId", "Ime");
            ViewBag.VoziloID = new SelectList(db.Voziloes, "VoziloId", "BrojRegistracije");
            return View();
        }

        // POST: Nalogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NalogId,VoziloID,KlijentID,MozeInostranstvo,VracaUInostranstvu,Datum")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Nalogs.Add(nalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlijentID = new SelectList(db.Klijents, "KlijentId", "Ime", nalog.KlijentID);
            ViewBag.VoziloID = new SelectList(db.Voziloes, "VoziloId", "BrojRegistracije", nalog.VoziloID);
            return View(nalog);
        }

        // GET: Nalogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalogs.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlijentID = new SelectList(db.Klijents, "KlijentId", "Ime", nalog.KlijentID);
            ViewBag.VoziloID = new SelectList(db.Voziloes, "VoziloId", "BrojRegistracije", nalog.VoziloID);
            return View(nalog);
        }

        // POST: Nalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NalogId,VoziloID,KlijentID,MozeInostranstvo,VracaUInostranstvu,Datum")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlijentID = new SelectList(db.Klijents, "KlijentId", "Ime", nalog.KlijentID);
            ViewBag.VoziloID = new SelectList(db.Voziloes, "VoziloId", "BrojRegistracije", nalog.VoziloID);
            return View(nalog);
        }

        // GET: Nalogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalogs.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // POST: Nalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nalog nalog = db.Nalogs.Find(id);
            db.Nalogs.Remove(nalog);
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
