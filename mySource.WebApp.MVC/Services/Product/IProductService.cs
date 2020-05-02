using mySource.WebApp.MVC.Models.Product;
using System.Collections.Generic;

namespace mySource.WebApp.MVC.Services.Product
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts();
    }
}
