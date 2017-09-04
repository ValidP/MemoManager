using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL2;

namespace MemoManager.Controllers
{
    public class EtatsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Etats
        public ActionResult Index()
        {
            return View(db.EtatSet.ToList());
        }

        // GET: Etats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etat etat = db.EtatSet.Find(id);
            if (etat == null)
            {
                return HttpNotFound();
            }
            return View(etat);
        }

        // GET: Etats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom")] Etat etat)
        {
            if (ModelState.IsValid)
            {
                db.EtatSet.Add(etat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etat);
        }

        // GET: Etats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etat etat = db.EtatSet.Find(id);
            if (etat == null)
            {
                return HttpNotFound();
            }
            return View(etat);
        }

        // POST: Etats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] Etat etat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etat);
        }

        // GET: Etats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etat etat = db.EtatSet.Find(id);
            if (etat == null)
            {
                return HttpNotFound();
            }
            return View(etat);
        }

        // POST: Etats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etat etat = db.EtatSet.Find(id);
            db.EtatSet.Remove(etat);
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
