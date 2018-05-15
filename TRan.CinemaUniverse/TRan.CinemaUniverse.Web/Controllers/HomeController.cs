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

        [OutputCache(CacheProfile = "cacheProfile1")]
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
    }
}