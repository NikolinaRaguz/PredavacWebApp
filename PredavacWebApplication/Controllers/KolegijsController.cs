using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PredavacWebApplication.Models;

namespace PredavacWebApplication.Controllers
{
    public class KolegijsController : Controller
    {
        private KolegijDBContext db = new KolegijDBContext();

        // GET: Kolegijs
        public ActionResult Index()
        {
            return View(db.Kolegij.ToList());
        }

        // GET: Kolegijs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // GET: Kolegijs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kolegijs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Nositelj,StudijskaGod")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Kolegij.Add(kolegij);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kolegij);
        }

        // GET: Kolegijs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegijs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Nositelj,StudijskaGod")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolegij).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kolegij);
        }

        // GET: Kolegijs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij kolegij = db.Kolegij.Find(id);
            db.Kolegij.Remove(kolegij);
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
        public ActionResult SearchIndex(string Naziv, string searchString)
        {

            //prazna lista za nazive gdje cemo staviti nazive iz baze
            var listaZaKolegij = new List<string>();

            //upit na bazu gdje dohvacamo nazive
            var nazivIzBaze = db.Kolegij.Select(x => x.Naziv).OrderBy(x => x);

            //napuniti praznu listu s razlicitim vrijednostima iz baze
            listaZaKolegij.AddRange(nazivIzBaze.Distinct());

            //prikazati listu na html stranici
            ViewBag.Naziv = new SelectList(listaZaKolegij);

            // moramo dohvatiti sve nazive iz baze
            // OVO JE NAJBITNIJE
            /*
             pomocu linq-a napravimo inner join te povezemo dvije tablice po odgovarajucem kljucu, a nakon toga
             dohvatimo polja koja nam trebaju i stavimo u viewModel
            
            viewModel predstavlja poseban model koji ne postoji u bazi, vec se sastoji od razlicitih polja iz vise modela u bazi, koristi se kada se korisniku treba prikazati 
            nesto iz vise tablica  

            Imajte na umu da je ovo INNER JOIN sto znaci da svaki kolegij mora imati predavaca kako bi dohvatio novi kolegijPredavacViewModel 
             */
            var kolegijPredavacViewModel = db.Kolegij
                .Join(db.Predavac, kolegij => kolegij.Id, predavac => predavac.KolegijId,
                    (kolegij, predavac) => new {kolegij, predavac})
                .Select(rezultat =>
                    new KolegijPredavacViewModel
                    {
                        Id = rezultat.kolegij.Id,
                        Naziv = rezultat.kolegij.Naziv,
                        Nositelj = rezultat.kolegij.Nositelj,
                        StudijskaGod = rezultat.kolegij.StudijskaGod,
                        Datum =  rezultat.predavac.Datum,
                        Ime = rezultat.predavac.Ime,
                        Prezime = rezultat.predavac.Prezime,
                        Tema = rezultat.predavac.Tema
                    }).ToList();


            // provjeriti je li string prazan i naci kolegije s tim nazivom
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                kolegijPredavacViewModel = kolegijPredavacViewModel.Where(x => x.Prezime.Contains(searchString)).ToList();
            }

            //provjera je li je odabran naziv i pretrazivanje po nazivu
            if (!string.IsNullOrWhiteSpace(Naziv))
            {
                kolegijPredavacViewModel = kolegijPredavacViewModel.Where(x => x.Naziv == Naziv).ToList();
            }

            // vratiti nadene kolegije na html formu
            return View(kolegijPredavacViewModel);
        }

        public ActionResult _KolegijPredavac(int? KolegijId)
        {
            if (KolegijId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<Predavac> Predavac = db.Predavac.Where(x => x.KolegijId == KolegijId);


            return PartialView(Predavac);
        }
        }
}
