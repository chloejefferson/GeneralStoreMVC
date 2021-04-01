using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class ProductController : Controller
    {
        //Add the application db context (link to database)
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Product
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //GET: Delete
        //Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product product = _db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        //POST: Delete
        // Product/Delete/{id}
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult Delete (int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}