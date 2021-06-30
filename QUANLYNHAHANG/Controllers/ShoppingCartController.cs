using System;
using System.Collections;
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
    public class ShoppingCartController : Controller
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
        // GET: ShoppingCart
        public ActionResult Index()
        {
            GetShoppingCart();
            var hashtable = new Hashtable();
            foreach (var Chitietdonhang in ShoppingCart)
            {
                if (hashtable[Chitietdonhang.Sanpham.Mã_SP] != null)
                {
                    (hashtable[Chitietdonhang.Sanpham.Mã_SP] as Chitietdonhang).Số_lượng += Chitietdonhang.Số_lượng;
                }
                else hashtable[Chitietdonhang.Sanpham.Mã_SP] = Chitietdonhang;
            }

            ShoppingCart.Clear();
            foreach (Chitietdonhang Chitietdonhang in hashtable.Values)
                ShoppingCart.Add(Chitietdonhang);
            return View(ShoppingCart);
        }


        // GET: ShoppingCart/Create
        [HttpPost]
        public ActionResult Create(string Mã_SP, int số_lượng)
        {
            GetShoppingCart();
            var sanpham = db.Sanphams.Find(Mã_SP);
            ShoppingCart.Add(new Chitietdonhang
            {
                Sanpham = sanpham,
                Số_lượng = số_lượng


            });

            return RedirectToAction("Index");
        }

        // GET: ShoppingCart/Edit/5
        [HttpPost]
        public ActionResult Edit(string [] Mã_SP,int [] số_lượng)
        {
            GetShoppingCart();
            ShoppingCart.Clear();
            if (Mã_SP !=null)
                for (int i = 0; i < Mã_SP.Length; i++)
                    if(số_lượng [i] >0)
                {
                    var sanpham = db.Sanphams.Find(Mã_SP[i]);
                    ShoppingCart.Add(new Chitietdonhang
                    {
                        Sanpham=sanpham,
                        Số_lượng =số_lượng[i]
                    });
                }
            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("Index");
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete()
        {

            GetShoppingCart();
            ShoppingCart.Clear();
            Session["ShoppingCart"] = ShoppingCart;
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