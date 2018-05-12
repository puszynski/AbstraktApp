using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbstraktApp.WebUI.Models;
using AbstraktApp.WebUI.ViewModels;
using Microsoft.AspNet.Identity;

namespace AbstraktApp.WebUI.Controllers
{
    public class ProductsController : BaseController
    {
        // GET: Products
        public ActionResult Index(int? categoryId = null)
        {
            // Filtrowanie (nie-asynchronieczne) 
            IEnumerable<Product> products;
            if (categoryId.HasValue)
            {
                if (_db.Categories.Any(c => c.ID == categoryId.Value))
                {
                    products = _db.Products.Where(p => p.CategoryId == categoryId.Value);
                    return View(products);
                }
            }

            products = _db.Products;
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            var modelWithCategory = new ProductViewModel();
            modelWithCategory.Categories = _db.Categories.Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString() });
            return View(modelWithCategory);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Buy(int? productId)
        {
            if (productId == null)
            {
                return RedirectToAction("Index");
            }

            var productToBuy = _db.Products.Find(productId);

            if (productToBuy != null)
            {
                var userId = User.Identity.GetUserId();
                var user = _db.Users.Find(userId);

                user.ProductsInCart.Add(productToBuy);

                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return View("Index");
        }
    }
}
