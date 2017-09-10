using System.Collections.Generic;

namespace HyperMedia
{
    public class ResourceData
    {
        public object item { get; private set; }
        public Dictionary<string, string> rels { get; set; }

        public ResourceData(object data)
        {
            item = data;
            rels = new Dictionary<string, string>();
        }

    }

    public static class ResourceDataExtensions
    {
        public static ResourceData WithLink(this ResourceData data, Link link)
        {
            data.rels.Add(link.Rel, link.Href);
            return data;
        }
    }
}
