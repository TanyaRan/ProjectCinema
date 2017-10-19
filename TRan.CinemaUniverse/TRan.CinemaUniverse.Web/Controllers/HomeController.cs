using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Web.Mvc;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.ViewModels.Home;

namespace TRan.CinemaUniverse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public HomeController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var movies = this.movieService
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
            // this.movieService.Update();

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