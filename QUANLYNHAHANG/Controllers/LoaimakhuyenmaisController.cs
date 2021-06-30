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
    public class LoaimakhuyenmaisController : Controller
    {
        private CT25Team111Entities db = new CT25Team111Entities();

        // GET: Loaimakhuyenmais
        public ActionResult Index()
        {
            return View(db.Loaimakhuyenmais.ToList());
        }

        // GET: Loaimakhuyenmais/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaimakhuyenmai loaimakhuyenmai = db.Loaimakhuyenmais.Find(id);
            if (loaimakhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(loaimakhuyenmai);
        }

        // GET: Loaimakhuyenmais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loaimakhuyenmais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Loại_mã_khuyến_mãi,Tên_loại_khuyến_mãi")] Loaimakhuyenmai loaimakhuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Loaimakhuyenmais.Add(loaimakhuyenmai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaimakhuyenmai);
        }

        // GET: Loaimakhuyenmais/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaimakhuyenmai loaimakhuyenmai = db.Loaimakhuyenmais.Find(id);
            if (loaimakhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(loaimakhuyenmai);
        }

        // POST: Loaimakhuyenmais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Loại_mã_khuyến_mãi,Tên_loại_khuyến_mãi")] Loaimakhuyenmai loaimakhuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaimakhuyenmai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaimakhuyenmai);
        }

        // GET: Loaimakhuyenmais/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaimakhuyenmai loaimakhuyenmai = db.Loaimakhuyenmais.Find(id);
            if (loaimakhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(loaimakhuyenmai);
        }

        // POST: Loaimakhuyenmais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loaimakhuyenmai loaimakhuyenmai = db.Loaimakhuyenmais.Find(id);
            db.Loaimakhuyenmais.Remove(loaimakhuyenmai);
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
