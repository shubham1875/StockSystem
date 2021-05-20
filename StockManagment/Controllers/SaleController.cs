using StockManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManagment.Controllers
{
    public class SaleController : Controller
    {
        StockSystemEntities1 db = new StockSystemEntities1();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale sale)
        {
            db.Sales.Add(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult UpdateSale(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(sale);
        }

        [HttpPost]
        public ActionResult UpdateSale(int id, Sale sale)
        {
            Sale sl = db.Sales.Where(x => x.id == id).SingleOrDefault();
            sl.SaleProduct = sale.SaleProduct;
            sl.SaleQuantity = sale.SaleQuantity;
            sl.SaleDate = sale.SaleDate;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult SaleDetails(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sale);
        }

        [HttpGet]
        public ActionResult DeleteSale(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sale);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, Sale sale)
        {
            db.Sales.Remove(db.Sales.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}