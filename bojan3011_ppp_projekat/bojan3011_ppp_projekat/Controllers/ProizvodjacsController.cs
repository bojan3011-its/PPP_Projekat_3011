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
    public class ProizvodjacsController : Controller
    {
        private RentacarDBContext db = new RentacarDBContext();

        // GET: Proizvodjacs
        public ActionResult Index()
        {
            var proizvodjacs = db.Proizvodjacs.Include(p => p.Drzava);
            return View(proizvodjacs.ToList());
        }

        // GET: Proizvodjacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodjac proizvodjac = db.Proizvodjacs.Find(id);
            if (proizvodjac == null)
            {
                return HttpNotFound();
            }
            return View(proizvodjac);
        }

        // GET: Proizvodjacs/Create
        public ActionResult Create()
        {
            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv");
            return View();
        }

        // POST: Proizvodjacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProizvodjacId,DrzavaID,Naziv")] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                db.Proizvodjacs.Add(proizvodjac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv", proizvodjac.DrzavaID);
            return View(proizvodjac);
        }

        // GET: Proizvodjacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodjac proizvodjac = db.Proizvodjacs.Find(id);
            if (proizvodjac == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv", proizvodjac.DrzavaID);
            return View(proizvodjac);
        }

        // POST: Proizvodjacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProizvodjacId,DrzavaID,Naziv")] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodjac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DrzavaID = new SelectList(db.Drzavas, "DrzavaId", "Naziv", proizvodjac.DrzavaID);
            return View(proizvodjac);
        }

        // GET: Proizvodjacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodjac proizvodjac = db.Proizvodjacs.Find(id);
            if (proizvodjac == null)
            {
                return HttpNotFound();
            }
            return View(proizvodjac);
        }

        // POST: Proizvodjacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvodjac proizvodjac = db.Proizvodjacs.Find(id);
            db.Proizvodjacs.Remove(proizvodjac);
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
