using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filmes1.Models;

namespace Filmes1.Controllers
{
    public class FilmesController : Controller
    {
        private DBFilmes db = new DBFilmes();

        // GET: Filmes
        public ActionResult Index(string search)
        {
            return View(db.CatalogoFilmes.Where(x => x.Titulo.Contains(search) || 
                                                x.Ano.Contains(search) || 
                                                x.TipoMidia.Contains(search) || 
                                                x.Elenco.Contains(search) || 
                                                x.Direcao.Contains(search) ||
                                                search == null).ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogoFilmes catalogoFilmes = db.CatalogoFilmes.Find(id);
            if (catalogoFilmes == null)
            {
                return HttpNotFound();
            }
            return View(catalogoFilmes);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Duracao,Ano,TipoMidia,Elenco,Direcao")] CatalogoFilmes catalogoFilmes)
        {
            if (ModelState.IsValid)
            {
                db.CatalogoFilmes.Add(catalogoFilmes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogoFilmes);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogoFilmes catalogoFilmes = db.CatalogoFilmes.Find(id);
            if (catalogoFilmes == null)
            {
                return HttpNotFound();
            }
            return View(catalogoFilmes);
        }

        // POST: Filmes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Duracao,Ano,TipoMidia,Elenco,Direcao")] CatalogoFilmes catalogoFilmes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogoFilmes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogoFilmes);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogoFilmes catalogoFilmes = db.CatalogoFilmes.Find(id);
            if (catalogoFilmes == null)
            {
                return HttpNotFound();
            }
            return View(catalogoFilmes);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatalogoFilmes catalogoFilmes = db.CatalogoFilmes.Find(id);
            db.CatalogoFilmes.Remove(catalogoFilmes);
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
