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
    public class DepartamentoController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Departamento
        public ActionResult Index()
        {
            return View(db.Departamentoes.ToList());
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentoes.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentoId,Nome")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Departamentoes.Add(departamento);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception Excecao)
                {
                    if (Excecao.InnerException != null &&
                       Excecao.InnerException.InnerException != null &&
                       Excecao.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, " Não é possivel inserir dois departementos com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Excecao.Message);
                    }

                    return View(departamento);
                }

                

            }

            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentoes.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentoId,Nome")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception Excecao)
                {
                    if (Excecao.InnerException != null &&
                      Excecao.InnerException.InnerException != null &&
                      Excecao.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, " Não é possivel inserir dois departementos com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Excecao.Message);
                    }

                    return View(departamento);
                  
                }
               
            }
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentoes.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = db.Departamentoes.Find(id);
            db.Departamentoes.Remove(departamento);
           
            //Tratamento Cascata 
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception Excecao)
            {
                if (Excecao.InnerException != null &&
                        Excecao.InnerException.InnerException != null &&
                        Excecao.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, " Não é possivel   Excluir  o departamento Porque Existe Cidades relacionada a ele, 1° Remova as Cidades e tente Novamente!!");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Excecao.Message);
                }
               
                return View(departamento);
            }

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
