using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using TRan.CinemaUniverse.Common;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Projections;

namespace TRan.CinemaUniverse.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectionsController : Controller
    {
        private readonly IProjectionService projectionService;
        private readonly IMovieService movieService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ProjectionsController(IProjectionService projectionService, IMovieService movieService, IUserService userService, IMapper mapper)
        {
            Guard.WhenArgument(projectionService, "projectionService").IsNull().Throw();
            Guard.WhenArgument(movieService, "movieService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.projectionService = projectionService;
            this.movieService = movieService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public ActionResult All(int? page)
        {
            var projections = this.projectionService
                .GetAll()
                .ProjectTo<ProjectionEditViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 4;

            return View(projections.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            // var list = this.userService.GetAll().Where(u => u.Roles.Any(r => r.RoleId == "b08dc228-b53e-4444-81bc-dedc956ec9ad")).ToList();
            var movie = new ProjectionCreateViewModel
            {
                // LecturersList = new SelectList(list, "Id", "UserName"),
                MoviesList = new SelectList(this.movieService.GetAll().ToList(), "Id", "Title")
            };

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectionCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[MainConstants.Error] = "Projection addition failed!";
                return this.View(model);
            }

            var projection = this.mapper.Map<Projection>(model);
            this.projectionService.Add(projection);

            this.TempData[MainConstants.Success] = "Projection added successfully!";

            return this.RedirectToAction("All", "Projections", new { area = "administration" });
        }
    }
}