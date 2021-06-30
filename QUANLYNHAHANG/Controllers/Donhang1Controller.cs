using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using QUANLYNHAHANG.Models;

namespace QUANLYNHAHANG.Controllers
{
    public class Donhang1Controller : Controller
    {
        private CT25Team111Entities db = new CT25Team111Entities();

        private List<Chitietdonhang> ShoppingCart = null;

        private void GetShoppingCart()
        {

            if (Session["ShoppingCart"] != null)
                ShoppingCart = Session["ShoppingCart"] as List<Chitietdonhang>;
            else
            {
                ShoppingCart = new List<Chitietdonhang>();
                Session["ShoppingCart"] = ShoppingCart;
            }
        }

        [Authorize(Roles = "Admin")]
        

        // GET: Donhang1
        public ActionResult Index()
        {
            var donhang1 = db.Donhang1.Include(d => d.Makhuyenmai);
            return View(donhang1.ToList());
        }

        // GET: Donhang1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhang1 donhang1 = db.Donhang1.Find(id);
            if (donhang1 == null)
            {
                return HttpNotFound();
            }
            return View(donhang1);
        }

        // GET: Donhang1/Create
        public ActionResult Create()
        {
            GetShoppingCart();
            ViewBag.Cart = ShoppingCart;
            ViewBag.Mã_khuyến_mãi = new SelectList(db.Makhuyenmais, "Mã_khuyến_mãi", "Tên_KM");
            return View();
        }

        // POST: Donhang1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donhang1 donhang1)
        {
            ValidateDonhang(donhang1);
            if (ModelState.IsValid)
            {
                donhang1.Ngày_đặt = DateTime.Now;
                donhang1.Mã_ĐH = Guid.NewGuid().ToString();
                db.Donhang1.Add(donhang1);
                db.SaveChanges();
                Session["ShoppingCart"]=null;
                return RedirectToAction("Index2", "Home");
            }

            GetShoppingCart();
            ViewBag.Cart = ShoppingCart;
            ViewBag.Mã_khuyến_mãi = new SelectList(db.Makhuyenmais, "Mã_khuyến_mãi", "Tên_KM", donhang1.Mã_khuyến_mãi);
            return View(donhang1);
        }
        private void ValidateDonhang(Donhang1 donhang1)
        {
            var regex = new Regex("[0-9]{3}");
            GetShoppingCart();
            if (ShoppingCart.Count == 0)
                ModelState.AddModelError("", "Không có sản phẩm nào trong giỏ hàng!");
            if (!regex.IsMatch(donhang1.SĐT))
                ModelState.AddModelError("SĐT", "Sai số điện thoại");
        }

        // GET: Donhang1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhang1 donhang1 = db.Donhang1.Find(id);
            if (donhang1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mã_khuyến_mãi = new SelectList(db.Makhuyenmais, "Mã_khuyến_mãi", "Tên_KM", donhang1.Mã_khuyến_mãi);
            return View(donhang1);
        }

        // POST: Donhang1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Donhang1 donhang1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mã_khuyến_mãi = new SelectList(db.Makhuyenmais, "Mã_khuyến_mãi", "Tên_KM", donhang1.Mã_khuyến_mãi);
            return View(donhang1);
        }

        // GET: Donhang1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhang1 donhang1 = db.Donhang1.Find(id);
            if (donhang1 == null)
            {
                return HttpNotFound();
            }
            return View(donhang1);
        }

        // POST: Donhang1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Donhang1 donhang1 = db.Donhang1.Find(id);
            db.Donhang1.Remove(donhang1);
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
