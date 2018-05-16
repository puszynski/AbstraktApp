using AbstraktApp.Domain.Abstract;
using AbstraktApp.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace AbstraktApp.WebUI.Controllers
{
    public class NewProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 6; // stronnicowanie(ilość wyświetlanych produktów)

        public NewProductController(IProductRepository productRepository)
        {
            repository = productRepository;            
        }

        // GET: NewProduct
        public ViewResult List(string category, int page = 1) // = 1 określa nam wartość default, nie musimy podawać parametru strony a i tak wyświetli pierwszy
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(viewModel);
        }
    }
}