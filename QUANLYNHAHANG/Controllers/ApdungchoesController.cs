using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUANLYNHAHANG.Models;

namespace QUANLYNHAHANG.Controllers
{
    public class ApdungchoesController : Controller
    {
        private CT25Team111Entities db = new CT25Team111Entities();

        // GET: Apdungchoes
        public ActionResult Index()
        {
            return View(db.Apdungchoes.ToList());
        }

        // GET: Apdungchoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apdungcho apdungcho = db.Apdungchoes.Find(id);
            if (apdungcho == null)
            {
                return HttpNotFound();
            }
            return View(apdungcho);
        }

        // GET: Apdungchoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apdungchoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Áp_dụng_cho,Tên_loại_áp_dụng")] Apdungcho apdungcho)
        {
            if (ModelState.IsValid)
            {
                db.Apdungchoes.Add(apdungcho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apdungcho);
        }

        // GET: Apdungchoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apdungcho apdungcho = db.Apdungchoes.Find(id);
            if (apdungcho == null)
            {
                return HttpNotFound();
            }
            return View(apdungcho);
        }

        // POST: Apdungchoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Áp_dụng_cho,Tên_loại_áp_dụng")] Apdungcho apdungcho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apdungcho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apdungcho);
        }

        // GET: Apdungchoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apdungcho apdungcho = db.Apdungchoes.Find(id);
            if (apdungcho == null)
            {
                return HttpNotFound();
            }
            return View(apdungcho);
        }

        // POST: Apdungchoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Apdungcho apdungcho = db.Apdungchoes.Find(id);
            db.Apdungchoes.Remove(apdungcho);
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
