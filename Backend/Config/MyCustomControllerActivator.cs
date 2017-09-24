using HyperMedia;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Backend.Config
{
    public class MyCustomControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var scope = request.GetDependencyScope() as WindsorDependencyScope;

            // Inject the current request into the underlying container
            

            return scope.GetService(controllerType) as IHttpController;
            // IocContainer.container.Resolve<IMyResourceLinker>(request);
            // resolve dependencies of the controller. . . .
            //   return Activator.CreateInstance(controllerType) as IHttpController;
        }
    }
}