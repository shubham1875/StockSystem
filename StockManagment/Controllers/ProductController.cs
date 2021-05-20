using StockManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManagment.Controllers
{
    public class ProductController : Controller
    {
        StockSystemEntities1 db = new StockSystemEntities1();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List <Product> list = db.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product product = db.Products.Where(x=>x.id==id).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product product)
        {
            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            pro.ProductName = product.ProductName;
            pro.ProductQuantity = product.ProductQuantity;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id,Product product)
        {
            db.Products.Remove(db.Products.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}