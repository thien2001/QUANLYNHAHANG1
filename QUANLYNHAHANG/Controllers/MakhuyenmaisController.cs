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
    public class MakhuyenmaisController : Controller
    {
        private CT25Team111Entities db = new CT25Team111Entities();

        // GET: Makhuyenmais
        public ActionResult Index()
        {
            var makhuyenmais = db.Makhuyenmais.Include(m => m.Apdungcho).Include(m => m.Loaimakhuyenmai);
            return View(makhuyenmais.ToList());
        }

        // GET: Makhuyenmais/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makhuyenmai makhuyenmai = db.Makhuyenmais.Find(id);
            if (makhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(makhuyenmai);
        }

        // GET: Makhuyenmais/Create
        public ActionResult Create()
        {
            ViewBag.Áp_dụng_cho = new SelectList(db.Apdungchoes, "Áp_dụng_cho", "Tên_loại_áp_dụng");
            ViewBag.Loại_mã_khuyến_mãi = new SelectList(db.Loaimakhuyenmais, "Loại_mã_khuyến_mãi", "Tên_loại_khuyến_mãi");
            return View();
        }

        // POST: Makhuyenmais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_khuyến_mãi,Tên_KM,Loại_mã_khuyến_mãi,Mức_giảm,Áp_dụng_cho,Trị_giá_từ,Thời_gian_bắt_đầu,Thời_gian_kết_thúc")] Makhuyenmai makhuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Makhuyenmais.Add(makhuyenmai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Áp_dụng_cho = new SelectList(db.Apdungchoes, "Áp_dụng_cho", "Tên_loại_áp_dụng", makhuyenmai.Áp_dụng_cho);
            ViewBag.Loại_mã_khuyến_mãi = new SelectList(db.Loaimakhuyenmais, "Loại_mã_khuyến_mãi", "Tên_loại_khuyến_mãi", makhuyenmai.Loại_mã_khuyến_mãi);
            return View(makhuyenmai);
        }

        // GET: Makhuyenmais/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makhuyenmai makhuyenmai = db.Makhuyenmais.Find(id);
            if (makhuyenmai == null)
            {
                return HttpNotFound();
            }
            ViewBag.Áp_dụng_cho = new SelectList(db.Apdungchoes, "Áp_dụng_cho", "Tên_loại_áp_dụng", makhuyenmai.Áp_dụng_cho);
            ViewBag.Loại_mã_khuyến_mãi = new SelectList(db.Loaimakhuyenmais, "Loại_mã_khuyến_mãi", "Tên_loại_khuyến_mãi", makhuyenmai.Loại_mã_khuyến_mãi);
            return View(makhuyenmai);
        }

        // POST: Makhuyenmais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mã_khuyến_mãi,Tên_KM,Loại_mã_khuyến_mãi,Mức_giảm,Áp_dụng_cho,Trị_giá_từ,Thời_gian_bắt_đầu,Thời_gian_kết_thúc")] Makhuyenmai makhuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makhuyenmai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Áp_dụng_cho = new SelectList(db.Apdungchoes, "Áp_dụng_cho", "Tên_loại_áp_dụng", makhuyenmai.Áp_dụng_cho);
            ViewBag.Loại_mã_khuyến_mãi = new SelectList(db.Loaimakhuyenmais, "Loại_mã_khuyến_mãi", "Tên_loại_khuyến_mãi", makhuyenmai.Loại_mã_khuyến_mãi);
            return View(makhuyenmai);
        }

        // GET: Makhuyenmais/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makhuyenmai makhuyenmai = db.Makhuyenmais.Find(id);
            if (makhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(makhuyenmai);
        }

        // POST: Makhuyenmais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Makhuyenmai makhuyenmai = db.Makhuyenmais.Find(id);
            db.Makhuyenmais.Remove(makhuyenmai);
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
