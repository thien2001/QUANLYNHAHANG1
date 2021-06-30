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
    public class LoaisanphamsController : Controller
    {
        private CT25Team111Entities db = new CT25Team111Entities();

        // GET: Loaisanphams
        public ActionResult Index()
        {
            return View(db.Loaisanphams.ToList());
        }

        // GET: Loaisanphams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // GET: Loaisanphams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loaisanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_loại_SP,Tên_loại_SP")] Loaisanpham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.Loaisanphams.Add(loaisanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisanpham);
        }

        // GET: Loaisanphams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // POST: Loaisanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mã_loại_SP,Tên_loại_SP")] Loaisanpham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisanpham);
        }

        // GET: Loaisanphams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // POST: Loaisanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            db.Loaisanphams.Remove(loaisanpham);
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
