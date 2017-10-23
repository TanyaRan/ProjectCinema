using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Genres;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Movies;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Actors;
using TRan.CinemaUniverse.Common;

namespace TRan.CinemaUniverse.Web.Areas.Administration.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        private readonly IActorService actorService;
        private readonly IMapper mapper;

        public MoviesController(IMovieService movieService, IGenreService genreService, IActorService actorService, IMapper mapper)
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

        public ActionResult Index(int? page)
        {
            var movies = this.movieService
                .GetAll()
                .ProjectTo<MovieEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 4;

            return View(movies.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult All(int? page)
        {
            var movies = this.movieService
                .GetAll()
                .ProjectTo<MovieEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 4;

            return View(movies.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Deleted(int? page)
        {
            var movies = this.movieService
                .GetDeleted()
                .ProjectTo<MovieEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            return View("All", movies.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var movie = new MovieCreateViewModel
            {
                GenresList = new SelectList(this.genreService.GetAll().ToList(), "Id", "Name"),
                ActorsList = new SelectList(this.actorService.GetAll().ToList(), "Id", "Name"),
                ActressesList = new SelectList(this.actorService.GetAll().ToList(), "Id", "Name")
            };

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[MainConstants.Error] = "Movie addition failed!";
                return this.View(model);
            }

            var movie = this.mapper.Map<Movie>(model);

            this.movieService.Add(movie);

            this.TempData[MainConstants.Success] = string.Format("Movie {0} added successfully!", model.Title);

            return this.RedirectToAction("All", "Movies", new { area = "administration" });
        }

        [HttpGet]
        public ActionResult Edit(Guid id, MovieEditViewModel model)
        {
            var movie = this.movieService
                .GetById(id);
            if (movie == null)
            {
                return View("NotFound");
            }

            model = this.mapper.Map<MovieEditViewModel>(movie);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var movie = this.mapper.Map<Movie>(model);
                this.movieService.Update(movie);
            }

            return this.RedirectToAction("All", "Movies", new { area = "administration" });
        }

        [HttpGet]
        public ActionResult Delete(Guid id, MovieEditViewModel model)
        {
            var movie = this.movieService.GetById(id);
            if (movie == null)
            {
                return View("NotFound");
            }

            model = this.mapper.Map<MovieEditViewModel>(movie);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MovieEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var movie = this.mapper.Map<Movie>(model);
                this.movieService.Delete(movie.Id);
            }

            return this.RedirectToAction("All", "Movies", new { area = "administration" });
        }

        private List<GenreEditViewModel> PopulateGenres(GenreEditViewModel model)
        {
            var genres = this.genreService
            .GetAll()
            .OrderBy(g => g.Name)
            .ProjectTo<GenreEditViewModel>()
            .ToList();

            return genres;
        }

        private List<ActorInputViewModel> PopulateActors(ActorInputViewModel model)
        {
            var actors = this.actorService
            .GetAll()
            .OrderBy(a => a.Name)
            .ProjectTo<ActorInputViewModel>()
            .ToList();

            return actors;
        }
    }
}