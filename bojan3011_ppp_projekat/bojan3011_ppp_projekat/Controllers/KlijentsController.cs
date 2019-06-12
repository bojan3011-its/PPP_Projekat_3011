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
    public class KlijentsController : Controller
    {
        private RentacarDBContext db = new RentacarDBContext();

        // GET: Klijents
        public ActionResult Index()
        {
            var klijents = db.Klijents.Include(k => k.Drzava);
            return View(klijents.ToList());
        }

        // GET: Klijents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijent klijent = db.Klijents.Find(id);
            if (klijent == null)
            {
                return HttpNotFound();
            }
            return View(klijent);
        }

        // GET: Klijents/Create
        public ActionResult Create()
        {
            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv");
            return View();
        }

        // POST: Klijents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlijentId,DrzavaID,Ime,Prezime,BrojLD,BrojNVD,BrojMVD")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                db.Klijents.Add(klijent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv", klijent.DrzavaID);
            return View(klijent);
        }

        // GET: Klijents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijent klijent = db.Klijents.Find(id);
            if (klijent == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv", klijent.DrzavaID);
            return View(klijent);
        }

        // POST: Klijents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KlijentId,DrzavaID,Ime,Prezime,BrojLD,BrojNVD,BrojMVD")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klijent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv", klijent.DrzavaID);
            return View(klijent);
        }

        // GET: Klijents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijent klijent = db.Klijents.Find(id);
            if (klijent == null)
            {
                return HttpNotFound();
            }
            return View(klijent);
        }

        // POST: Klijents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klijent klijent = db.Klijents.Find(id);
            db.Klijents.Remove(klijent);
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
