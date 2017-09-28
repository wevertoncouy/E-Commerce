using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class CompanhiaController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Companhia
        public ActionResult Index()
        {
            return View(db.Companhias.ToList());
        }

        // GET: Companhia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = db.Companhias.Find(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // GET: Companhia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companhia/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanhiaId,Nome,Telefone,Endereço,Logo")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                db.Companhias.Add(companhia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companhia);
        }

        // GET: Companhia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = db.Companhias.Find(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // POST: Companhia/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanhiaId,Nome,Telefone,Endereço,Logo")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companhia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companhia);
        }

        // GET: Companhia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = db.Companhias.Find(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // POST: Companhia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Companhia companhia = db.Companhias.Find(id);
            db.Companhias.Remove(companhia);
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
