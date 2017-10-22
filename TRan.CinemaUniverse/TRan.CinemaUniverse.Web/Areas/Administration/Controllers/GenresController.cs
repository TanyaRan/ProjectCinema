using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using TRan.CinemaUniverse.Common;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Genres;
using TRan.CinemaUniverse.Web.Controllers;

namespace TRan.CinemaUniverse.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            Guard.WhenArgument(genreService, "genreService").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.genreService = genreService;
            this.mapper = mapper;
        }

        public ActionResult All(int? page)
        {
            var genres = this.genreService
                .GetAll()
                .ProjectTo<GenreEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            return View(genres.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Deleted(int? page)
        {
            var genres = this.genreService
                .GetDeleted()
                .ProjectTo<GenreEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            return View("All", genres.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genre = new GenreCreateViewModel();

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[MainConstants.Error] = "Genre addition failed!";
                return this.View(model);
            }

            var genre = this.mapper.Map<Genre>(model);
            this.genreService.Add(genre);

            this.TempData[MainConstants.Success] = string.Format("Genre {0} added successfully!", model.Name);

            return this.RedirectToAction("All", "Genres", new { area = "administration" });
        }

        [HttpGet]
        public ActionResult Edit(Guid id, GenreEditViewModel model)
        {
            var genre = this.genreService
                .GetById(id);
            if (genre == null)
            {
                return View("NotFound");
            }

            model = this.mapper.Map<GenreEditViewModel>(genre);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenreEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var genre = this.mapper.Map<Genre>(model);
            this.genreService.Update(genre);

            return this.RedirectToAction("All", "Genres", new { area = "administration" });
        }

        [HttpGet]
        public ActionResult Delete(Guid id, GenreEditViewModel model)
        {
            var genre = this.genreService.GetById(id);
            if (genre == null)
            {
                return View("NotFound");
            }

            model = this.mapper.Map<GenreEditViewModel>(genre);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GenreEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var genre = this.mapper.Map<Genre>(model);
                this.genreService.Delete(genre.Id);
            }

            return this.RedirectToAction("All", "Genres", new { area = "administration" });
        }
    }
}