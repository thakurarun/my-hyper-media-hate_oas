using Ploeh.Hyprlinkr;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;

namespace HyperMedia
{
    public interface IMyResourceLinker : IResourceLinker
    {
        Link From<T>(string rel, Uri uri) where T : ApiController;
        Link From<T>(string rel, Expression<Action<T>> method) where T : ApiController;
    }
    public class MyResourceLinker : RouteLinker, IMyResourceLinker
    {
        public MyResourceLinker(HttpRequestMessage request) : base(request)
        { }

        public Link From<T>(string rel, Expression<Action<T>> method) where T : ApiController
        {
            return new Link(rel, base.GetUri<T>(method).AbsolutePath);
        }

        public Link From<T>(string rel, Uri uri) where T : ApiController
        {
            return new Link(rel, uri.AbsolutePath);
        }
    }
}
