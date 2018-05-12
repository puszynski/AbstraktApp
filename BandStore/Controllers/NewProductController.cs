using AbstraktApp.Domain.Abstract;
using BandStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandStore.Controllers
{
    public class NewProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4; // stronnicowanie(ilość wyświetlanych produktów)

        public NewProductController(IProductRepository productRepository)
        {
            repository = productRepository;
            
        }

        // GET: NewProduct
        public ViewResult List(int page = 1) // = 1 określa nam wartość default, nie musimy podawać parametru strony a i tak wyświetli pierwszy
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                .OrderBy
            }


            return View(repository.Products
                .OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize)); // stronnicowanie
        }
    }
}