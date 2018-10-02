using MvcMovieSampleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository _homeRepository;

        public HomeController(IHomeRepository repo)
        {
            _homeRepository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.RepoMessage = _homeRepository.GetAboutMessage();
            ViewBag.Message =  $"This time updates on each refresh showing the Transient nature of the controller: {DateTime.Now.ToLongTimeString()}.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}