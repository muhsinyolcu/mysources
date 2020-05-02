using mySource.WebApp.MVC.Models.Product;
using System.Collections.Generic;

namespace mySource.WebApp.MVC.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly List<ProductViewModel> _productList = new List<ProductViewModel>()
        {
            new ProductViewModel(){ ProductId = 1, ProductName = "Sugar", ProductPrice = 15.4m },
            new ProductViewModel(){ ProductId = 2, ProductName = "Salt", ProductPrice = 10m },
            new ProductViewModel(){ ProductId = 3, ProductName = "Bread", ProductPrice = 0.70m }
        };

        public List<ProductViewModel> GetProducts()
        {
            return _productList;
        }
    }
}