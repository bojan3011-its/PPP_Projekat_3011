﻿using System;
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
    public class DrzavasController : Controller
    {
        private RentacarDBContext db = new RentacarDBContext();

        // GET: Drzavas
        public ActionResult Index()
        {
            return View(db.Drzavas.ToList());
        }

        // GET: Drzavas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzavas.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // GET: Drzavas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drzavas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrzavaId,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Drzavas.Add(drzava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drzava);
        }

        // GET: Drzavas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzavas.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: Drzavas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrzavaId,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drzava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drzava);
        }

        // GET: Drzavas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzavas.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: Drzavas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drzava drzava = db.Drzavas.Find(id);
            db.Drzavas.Remove(drzava);
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
