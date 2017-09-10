using System;
using System.Linq.Expressions;
using System.Web.Http;

namespace HyperMedia
{
    public interface IResourceLinker
    {
        Link From<T>(string rel, Expression<Action<T>> method);
    }
    public class ResourceLinker : IResourceLinker
    {
        public ResourceLinker()
        {

        }

        public Link From<T>(string rel, Expression<Action<T>> method) // where T : ApiController
        {
            method.
            return new Link(rel, "link to product");
            //var href = controller.Url.Link(rel, method.);
            //return new Link(rel, href);
        }
    }
}
