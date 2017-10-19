using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using TRan.CinemaUniverse.Common;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels;
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

        public ActionResult All()
        {
            var genres = this.genreService
                .GetAll()
                .ProjectTo<GenreViewModel>()
                .ToList();

            return View(genres);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genre = new GenreViewModel();

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreViewModel genreModel)
        {
            if (this.ModelState.IsValid)
            {
                var mappedGenre = this.mapper.Map<Genre>(genreModel);

                this.genreService.Add(mappedGenre);
            }

            // this.TempData[GlobalConstants.SuccessMessage] = string.Format("Genre {0} added successfully!", genreModel.Name);

            return this.RedirectToAction("All", "Genres", new { area = "administration" });
        }
    }
}