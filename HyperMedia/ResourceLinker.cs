using Ploeh.Hyprlinkr;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace HyperMedia
{
    public interface IResourceLinker
    {
        Link From<T>(string rel, Uri uri) where T : ApiController;
    }
    public class ResourceLinker : IResourceLinker
    {
        public ResourceLinker()
        {

        }

        public Link From<T>(string rel, Uri uri) where T : ApiController
        {
            
            return new HyperMedia.Link(rel, uri.ToString());
            //var href = controller.Url.Link(rel, method.);
            //return new Link(rel, href);
        }
    }
}
