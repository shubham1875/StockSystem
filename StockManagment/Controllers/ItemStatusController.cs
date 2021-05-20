using StockManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManagment.Controllers
{
    public class ItemStatusController : Controller
    {
        StockSystemEntities1 db = new StockSystemEntities1();
        // GET: ItemStatus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayOrders()
        {
            List<PurchaseItem> list = db.PurchaseItems.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult UpdateOrderStatus(int id)
        {
            PurchaseItem item = db.PurchaseItems.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateOrderStatus(int id, PurchaseItem item)
        {
            PurchaseItem pur = db.PurchaseItems.Where(x => x.id == id).SingleOrDefault();
            pur.CustmorName = item.CustmorName;
            pur.CustmorEmail = item.CustmorEmail;
            pur.CustmorPhoneNumber = item.CustmorPhoneNumber;
            pur.CustmorDileveryAddress = item.CustmorDileveryAddress;
            pur.ItemName = item.ItemName;
            pur.ItemQuantity = item.ItemQuantity;
            pur.ItemPurchaseDate = item.ItemPurchaseDate;
            pur.ItemPurchaseStaus = item.ItemPurchaseStaus;
            db.SaveChanges();
            return RedirectToAction("DisplayOrders");
        }

        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            PurchaseItem item = db.PurchaseItems.Where(x => x.id == id).SingleOrDefault();
            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteOrder(int id, PurchaseItem item)
        {
            db.PurchaseItems.Remove(db.PurchaseItems.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayOrders");
        }
    }
}