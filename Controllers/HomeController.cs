using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSample.Models;

namespace MVCSample.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private ILinkRepository linksRepository;

        public HomeController(ILinkRepository linksRepository)
        {
            this.linksRepository = linksRepository;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            IEnumerable<Link> links = linksRepository.GetLinks();
            return View("index", links);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
