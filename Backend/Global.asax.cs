using Backend.Config;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace Backend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IocContainer.Setup();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //GlobalConfiguration.Configuration.Services
            //            .Replace(typeof(IHttpControllerActivator), new MyCustomControllerActivator());
            GlobalConfiguration
                .Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
