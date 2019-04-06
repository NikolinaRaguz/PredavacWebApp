using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PredavacWebApplication.Models;

namespace PredavacWebApplication.Controllers
{
    public class PredavacsController : Controller
    {
        private KolegijDBContext db = new KolegijDBContext();

        // GET: Predavacs
        public ActionResult Index()
        {
            var predavac = db.Predavac.Include(p => p.Kolegij);
            return View(predavac.ToList());
        }

        // GET: Predavacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predavac predavac = db.Predavac.Find(id);
            if (predavac == null)
            {
                return HttpNotFound();
            }
            return View(predavac);
        }

        // GET: Predavacs/Create
        public ActionResult Create()
        {
            ViewBag.KolegijId = new SelectList(db.Kolegij, "Id", "Naziv");
            return View();
        }

        // POST: Predavacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Prezime,Tema,Datum,BrStudent,KolegijId")] Predavac predavac)
        {
            if (ModelState.IsValid)
            {
                db.Predavac.Add(predavac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KolegijId = new SelectList(db.Kolegij, "Id", "Naziv", predavac.KolegijId);
            return View(predavac);
        }

        // GET: Predavacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predavac predavac = db.Predavac.Find(id);
            if (predavac == null)
            {
                return HttpNotFound();
            }
            ViewBag.KolegijId = new SelectList(db.Kolegij, "Id", "Naziv", predavac.KolegijId);
            return View(predavac);
        }

        // POST: Predavacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Prezime,Tema,Datum,BrStudent,KolegijId")] Predavac predavac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predavac).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KolegijId = new SelectList(db.Kolegij, "Id", "Naziv", predavac.KolegijId);
            return View(predavac);
        }

        // GET: Predavacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predavac predavac = db.Predavac.Find(id);
            if (predavac == null)
            {
                return HttpNotFound();
            }
            return View(predavac);
        }

        // POST: Predavacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predavac predavac = db.Predavac.Find(id);
            db.Predavac.Remove(predavac);
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
