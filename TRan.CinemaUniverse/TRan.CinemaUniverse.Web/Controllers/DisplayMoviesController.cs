using AutoMapper;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.ViewModels.DisplayMovies;

namespace TRan.CinemaUniverse.Web.Controllers
{
    public class DisplayMoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        private readonly IActorService actorService;
        private readonly IMapper mapper;

        public DisplayMoviesController(IMovieService movieService, IGenreService genreService, IActorService actorService, IMapper mapper)
        {
            Guard.WhenArgument(movieService, "movieService").IsNull().Throw();
            Guard.WhenArgument(genreService, "genreService").IsNull().Throw();
            Guard.WhenArgument(actorService, "actorService").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.movieService = movieService;
            this.genreService = genreService;
            this.actorService = actorService;
            this.mapper = mapper;
        }

        public ActionResult Details(Guid id)
        {
            var movie = this.movieService
                .GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            
            var viewModel = this.mapper.Map<MovieFullViewModel>(movie);

            return View(viewModel);
        }
    }
}