using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRan.CinemaUniverse.Common;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Actors;

namespace TRan.CinemaUniverse.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin, Lecturer")]
    public class ActorsController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IActorService actorService;
        private readonly IMapper mapper;

        public ActorsController(IMovieService movieService, IActorService actorService, IMapper mapper)
        {
            Guard.WhenArgument(movieService, "movieService").IsNull().Throw();
            Guard.WhenArgument(actorService, "actorService").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.movieService = movieService;
            this.actorService = actorService;
            this.mapper = mapper;
        }

        public ActionResult All(int? page)
        {
            var actors = this.actorService
                .GetAll()
                .ProjectTo<ActorEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            return View(actors.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var actor = new ActorCreateViewModel();

            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActorCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[MainConstants.Error] = "Actor addition failed!";
                return this.View(model);
            }

            var genre = this.mapper.Map<Actor>(model);
            this.actorService.Add(genre);

            this.TempData[MainConstants.Success] = string.Format("Actor {0} added successfully!", model.Name);

            return this.RedirectToAction("All", "Actors", new { area = "administration" });
        }
    }
}