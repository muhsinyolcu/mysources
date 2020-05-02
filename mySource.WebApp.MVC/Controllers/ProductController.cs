using mySource.WebApp.MVC.Services.Product;
using System.Web.Mvc;

namespace mySource.WebApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            return View(_productService.GetProducts());
        }
    }
}