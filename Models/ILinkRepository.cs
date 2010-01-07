using System.Collections.Generic;
using System.Web.UI.MobileControls;

namespace MVCSample.Models
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetLinks();
    }

    public class Link
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public Link(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }


    public class InMemoryLinks : ILinkRepository
    {
        public IEnumerable<Link> GetLinks()
        {
            return new List<Link>
                {
                    new Link("Reddit", "http://reddit.com"),
                    new Link("Asp.net", "http://asp.net"),
                    new Link("Asp.net MVC", "http://asp.net/mvc")
                };
        }
    }


}