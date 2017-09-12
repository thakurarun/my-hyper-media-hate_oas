using Ploeh.Hyprlinkr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace HyperMedia
{
    public class MyCustomControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            //if (controllerType == typeof(HomeController))
            //    return new HomeController(
            //        new RouteLinker(
            //            request));

            return Activator.CreateInstance(controllerType, new RouteLinker(request)) as IHttpController;

            //return new DefaultHttpControllerActivator().Create(
            //    request,
            //    controllerDescriptor,
            //    controllerType);
        }
    }
}
