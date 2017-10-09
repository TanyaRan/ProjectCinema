using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Models.Home;

namespace TRan.CinemaUniverse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService moviesService;

        public HomeController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Index()
        {
            var movies = this.moviesService
                .GetAll()
                .Select(x => new MovieViewModel
                {
                    Title = x.Title,
                    Description = x.Description,
                    Director = x.Director,
                    ImageUrl = x.ImageUrl
                })
                .ToList();

            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}