using AbstraktApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstraktApp.WebUI.Controllers
{
    //[Authorize]
    public class ReviewsController : BaseController
    {
        // GET: Reviews
        public ActionResult Index([Bind(Prefix = "Id")]int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                return View(product);
            }

            return HttpNotFound();
        }

        // GET
        [Authorize]
        public ActionResult Create(int productId)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Review obj)
        {
            if (ModelState.IsValid)
            {
                obj.Author = User.Identity.Name;
                _db.Reviews.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index", new { id = obj.ProductId });
            }

            return View(obj);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            // Sprawdzenie autoryzacji
            var editReview = _db.Reviews.Find(id);

            if (editReview.Author == User.Identity.Name)
            {
                if (editReview != null)
                {
                    return View(editReview);
                }
            }

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Exclude = "Author")] Review obj)  // [Bind(Exclude ="Author")] Usuwa możliwość dojścia do pola Author, bez tego można dodać/zedytować nazwe authora wpisując np ../Reviews/Edit/1?author=ZhackowaneImie
        {
            if (obj.Author == User.Identity.Name)
            {
                if (ModelState.IsValid)
                {
                    // Pobieramy konkretną encję która jest zgodna z naszym modelem (chyba na podstawie ID)
                    _db.Entry(obj).State = EntityState.Modified; // I dajemy znak że encja zostałą zmodyfikowana
                    _db.SaveChanges();

                    return RedirectToAction("Index", new { id = obj.ProductId });
                }
            }

            return RedirectToAction("Index", "Products");
        }
    }
}