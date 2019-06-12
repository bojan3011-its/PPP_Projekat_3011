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
    public class VoziloesController : Controller
    {
        private RentacarDBContext db = new RentacarDBContext();

        // GET: Voziloes
        public ActionResult Index()
        {
            var voziloes = db.Voziloes.Include(v => v.KategorijaVozila).Include(v => v.Proizvodjac);
            return View(voziloes.ToList());
        }

        // GET: Voziloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozilo vozilo = db.Voziloes.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // GET: Voziloes/Create
        public ActionResult Create()
        {
            ViewBag.KategorijaID = new SelectList(db.KategorijaVozilas, "KategorijaId", "Oznaka");
            ViewBag.ProizvodjacID = new SelectList(db.Proizvodjacs, "ProizvodjacId", "Naziv");
            return View();
        }

        // POST: Voziloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoziloId,KategorijaID,ProizvodjacID,BrojRegistracije,Model,Godiste,CenaPoDanu")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                db.Voziloes.Add(vozilo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategorijaID = new SelectList(db.KategorijaVozilas, "KategorijaId", "Oznaka", vozilo.KategorijaID);
            ViewBag.ProizvodjacID = new SelectList(db.Proizvodjacs, "ProizvodjacId", "Naziv", vozilo.ProizvodjacID);
            return View(vozilo);
        }

        // GET: Voziloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozilo vozilo = db.Voziloes.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategorijaID = new SelectList(db.KategorijaVozilas, "KategorijaId", "Oznaka", vozilo.KategorijaID);
            ViewBag.ProizvodjacID = new SelectList(db.Proizvodjacs, "ProizvodjacId", "Naziv", vozilo.ProizvodjacID);
            return View(vozilo);
        }

        // POST: Voziloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoziloId,KategorijaID,ProizvodjacID,BrojRegistracije,Model,Godiste,CenaPoDanu")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vozilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategorijaID = new SelectList(db.KategorijaVozilas, "KategorijaId", "Oznaka", vozilo.KategorijaID);
            ViewBag.ProizvodjacID = new SelectList(db.Proizvodjacs, "ProizvodjacId", "Naziv", vozilo.ProizvodjacID);
            return View(vozilo);
        }

        // GET: Voziloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozilo vozilo = db.Voziloes.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // POST: Voziloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vozilo vozilo = db.Voziloes.Find(id);
            db.Voziloes.Remove(vozilo);
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
