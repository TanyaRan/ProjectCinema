using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public HomeController(IMoviesService moviesService, IMapper mapper)
        {
            this.moviesService = moviesService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var movies = this.moviesService
                .GetAll()
                .ProjectTo<MovieViewModel>()
                .ToList();

            var viewModel = new HomeViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(MovieViewModel model)
        {
            // this.moviesService.Update();

            return RedirectToAction("About");
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