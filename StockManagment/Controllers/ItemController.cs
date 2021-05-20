using StockManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManagment.Controllers
{
    public class ItemController : Controller
    {
        StockSystemEntities1 db = new StockSystemEntities1();
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayItems()
        {
            List<PurchaseItem> list = db.PurchaseItems.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseItems()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseItems(PurchaseItem item)
        {
            db.PurchaseItems.Add(item);
            db.SaveChanges();
            return RedirectToAction("DisplayItems");
        }
    }
}