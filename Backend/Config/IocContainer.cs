using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Routing;
namespace Backend.Config
{
    public static class IocContainer
    {
        public static IWindsorContainer Container { get; private set; }

        public static void Setup()
        {
            Container = new WindsorContainer().Install(FromAssembly.This());

            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }

    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)_kernel.Resolve(controllerType);
        }
    }

    internal class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
            _scope = container.BeginScope();
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t)
            ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t)
            .Cast<object>().ToArray();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }

    internal sealed class WindsorHttpDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorHttpDependencyResolver(IWindsorContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t)
             ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t)
            .Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public void Dispose()
        {
        }
    }
}