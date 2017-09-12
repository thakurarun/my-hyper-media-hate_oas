using System;

namespace HyperMedia
{
    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public Link(string rel, string href)
        {
            Rel = rel;
            Href = href;
        }
    }

    //public class DataLink<T> : Link
    //{
    //    public T data { get; set; }
    //    public DataLink(string rel, string href, T data) : base(rel, href)
    //    {
    //        this.data = data;
    //    }
    //}
}
