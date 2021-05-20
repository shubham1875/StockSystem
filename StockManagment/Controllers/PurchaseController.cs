using StockManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManagment.Controllers
{
    public class PurchaseController : Controller
    {
        StockSystemEntities1 db = new StockSystemEntities1();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult UpdatePurchase(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(purchase);
        }

        [HttpPost]
        public ActionResult UpdatePurchase(int id, Purchase purchase)
        {
            Purchase pur = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            pur.PurchaseProduct = purchase.PurchaseProduct;
            pur.PurchaseQuantity = purchase.PurchaseQuantity;
            pur.PurchaseDate = purchase.PurchaseDate;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult PurchaseDetails(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(purchase);
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(purchase);
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase purchase)
        {
            db.Purchases.Remove(db.Purchases.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }
}