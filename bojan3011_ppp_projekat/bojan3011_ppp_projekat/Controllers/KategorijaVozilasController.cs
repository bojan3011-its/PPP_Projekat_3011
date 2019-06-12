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
    public class KategorijaVozilasController : Controller
    {
        private RentacarDBContext db = new RentacarDBContext();

        // GET: KategorijaVozilas
        public ActionResult Index()
        {
            return View(db.KategorijaVozilas.ToList());
        }

        // GET: KategorijaVozilas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaVozila kategorijaVozila = db.KategorijaVozilas.Find(id);
            if (kategorijaVozila == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaVozila);
        }

        // GET: KategorijaVozilas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KategorijaVozilas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategorijaId,Oznaka")] KategorijaVozila kategorijaVozila)
        {
            if (ModelState.IsValid)
            {
                db.KategorijaVozilas.Add(kategorijaVozila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorijaVozila);
        }

        // GET: KategorijaVozilas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaVozila kategorijaVozila = db.KategorijaVozilas.Find(id);
            if (kategorijaVozila == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaVozila);
        }

        // POST: KategorijaVozilas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategorijaId,Oznaka")] KategorijaVozila kategorijaVozila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorijaVozila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorijaVozila);
        }

        // GET: KategorijaVozilas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaVozila kategorijaVozila = db.KategorijaVozilas.Find(id);
            if (kategorijaVozila == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaVozila);
        }

        // POST: KategorijaVozilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategorijaVozila kategorijaVozila = db.KategorijaVozilas.Find(id);
            db.KategorijaVozilas.Remove(kategorijaVozila);
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
