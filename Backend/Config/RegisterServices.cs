using System;
using Backend.Controller.Product;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HyperMedia;
using Castle.Windsor.Installer;

namespace Backend.Config
{
    public class RegisterServices : IWindsorInstaller
    {
        /// public WindsorContainer container = new WindsorContainer();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMyResourceLinker>().ImplementedBy<MyResourceLinker>());
            container.Register(Component.For<IListController>().ImplementedBy<ListController>());
            container.Register(Component.For<IProductDataService>().ImplementedBy<ProductDataService>());
        }
        
    }
}