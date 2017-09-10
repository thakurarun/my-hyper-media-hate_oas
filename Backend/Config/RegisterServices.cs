using Backend.Controller.Product;
using Microsoft.Practices.Unity;

namespace Backend.Config
{
    public static class RegisterServices
    {
        public static IUnityContainer container = new UnityContainer();
        public static void Register()
        {
            container.RegisterType<IProductDataService, ProductDataService>(new HierarchicalLifetimeManager());

            // Other Web API configuration not shown.
        }
    }
}