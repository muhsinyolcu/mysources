using mySource.WebApp.MVC.Services.Product;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace mySource.WebApp.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProductService, ProductService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}