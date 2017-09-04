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
    public class MemosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Memos
        public ActionResult Index()
        {
            var memoSet = db.MemoSet.Include(m => m.Personne).Include(m => m.Equipe).Include(m => m.Categorie).Include(m => m.Etat);
            return View(memoSet.ToList());
        }

        // GET: Memos
        public ActionResult IndexDev()
        {
            var memoSet = db.MemoSet.Include(m => m.Personne).Include(m => m.Equipe).Include(m => m.Categorie).Include(m => m.Etat);
            return View(memoSet.ToList());
        }

        // GET: Memos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.MemoSet.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // GET: Memos/Create
        public ActionResult Create()
        {
            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom");
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe");
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie");
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom");
            return View();
        }

        // POST: Memos/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Contenu,DateExecution,Delai,Status,Priorite,PersonneId,DateFin,EquipeId,CategorieId,StatusId")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.MemoSet.Add(memo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom", memo.PersonneId);
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe", memo.EquipeId);
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie", memo.CategorieId);
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom", memo.EtatId);
            return View(memo);
        }


        // GET: Memos/Create
        public ActionResult CreateResponsable()
        {
            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom");
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe");
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie");
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom");
            return View();
        }

        // POST: Memos/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateResponsable([Bind(Include = "Id,Contenu,DateExecution,Delai,Status,Priorite,PersonneId,DateFin,EquipeId,CategorieId,StatusId")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                memo.DateExecution = DateTime.Now;
                memo.Etat = db.EtatSet.Find(1);
                db.MemoSet.Add(memo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom", memo.PersonneId);
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe", memo.EquipeId);
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie", memo.CategorieId);
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom", memo.EtatId);
            return View(memo);
        }



        // GET: Memos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.MemoSet.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom", memo.PersonneId);
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe", memo.EquipeId);
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie", memo.CategorieId);
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom", memo.EtatId);
            return View(memo);
        }

        // POST: Memos/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Contenu,DateExecution,Delai,Status,Priorite,PersonneId,DateFin,EquipeId,CategorieId,EtatId")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom", memo.PersonneId);
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe", memo.EquipeId);
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie", memo.CategorieId);
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom", memo.EtatId);
            return View(memo);
        }



        // GET: Memos/Edit/5
        public ActionResult EditDeveloppeur(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.MemoSet.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom", memo.PersonneId);
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe", memo.EquipeId);
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie", memo.CategorieId);
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom", memo.EtatId);
            return View(memo);
        }

        // POST: Memos/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDeveloppeur([Bind(Include = "Id,Contenu,DateExecution,Delai,Status,Priorite,PersonneId,DateFin,EquipeId,CategorieId,EtatId")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                
                if (memo.EtatId == 3)
                {
                    memo.DateFin = DateTime.Now;
                }


                db.Entry(memo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonneId = new SelectList(db.PersonneSet, "Id", "Nom", memo.PersonneId);
            ViewBag.EquipeId = new SelectList(db.EquipeSet, "Id", "NomEquipe", memo.EquipeId);
            ViewBag.CategorieId = new SelectList(db.CategorieSet, "Id", "NomCategorie", memo.CategorieId);
            ViewBag.EtatId = new SelectList(db.EtatSet, "Id", "Nom", memo.EtatId);
            return View(memo);
        }

        // GET: Memos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.MemoSet.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // POST: Memos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Memo memo = db.MemoSet.Find(id);
            db.MemoSet.Remove(memo);
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
