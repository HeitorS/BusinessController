using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessController.Models;

namespace BusinessController.Controllers
{
    public class LoginController : Controller
    {
        private Matriz db = new Matriz();

        // GET: Login
        public ActionResult Index()
        {
            var mTUSUARIO = db.MTUSUARIO.Include(m => m.MTPESSOA);
            return View(mTUSUARIO.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTUSUARIO mTUSUARIO = db.MTUSUARIO.Find(id);
            if (mTUSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(mTUSUARIO);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            ViewBag.IDPESSOA = new SelectList(db.MTPESSOA, "MTPESSOA_ID", "MTPESSOA_NOME");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOGIN,EMAIL,SENHA,ATIVO,PERFIL,NOME,SOBRENOME,IDPESSOA")] MTUSUARIO mTUSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.MTUSUARIO.Add(mTUSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPESSOA = new SelectList(db.MTPESSOA, "MTPESSOA_ID", "MTPESSOA_NOME", mTUSUARIO.IDPESSOA);
            return View(mTUSUARIO);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTUSUARIO mTUSUARIO = db.MTUSUARIO.Find(id);
            if (mTUSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPESSOA = new SelectList(db.MTPESSOA, "MTPESSOA_ID", "MTPESSOA_NOME", mTUSUARIO.IDPESSOA);
            return View(mTUSUARIO);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOGIN,EMAIL,SENHA,ATIVO,PERFIL,NOME,SOBRENOME,IDPESSOA")] MTUSUARIO mTUSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mTUSUARIO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPESSOA = new SelectList(db.MTPESSOA, "MTPESSOA_ID", "MTPESSOA_NOME", mTUSUARIO.IDPESSOA);
            return View(mTUSUARIO);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTUSUARIO mTUSUARIO = db.MTUSUARIO.Find(id);
            if (mTUSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(mTUSUARIO);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MTUSUARIO mTUSUARIO = db.MTUSUARIO.Find(id);
            db.MTUSUARIO.Remove(mTUSUARIO);
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
