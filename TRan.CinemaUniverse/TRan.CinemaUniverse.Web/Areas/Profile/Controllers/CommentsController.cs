using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using TRan.CinemaUniverse.Common;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Profile.ViewModels.Comments;

namespace TRan.CinemaUniverse.Web.Areas.Profile.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            Guard.WhenArgument(commentService, "commentService").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.commentService = commentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int itemsPerPage = 4;

            var comments = this.commentService
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .ThenBy(x => x.AuthorId)
                .ProjectTo<CommentViewModel>()
                .ToList();

            return View(comments.ToPagedList(pageNumber, itemsPerPage));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var comment = new CommentCreateViewModel();
            return this.View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var comment = this.mapper.Map<Comment>(model);

            if (this.User.Identity.IsAuthenticated)
            {
                comment.AuthorId = this.User.Identity.GetUserId();
                comment.CreatedOn = DateTime.Now;
            }

            this.commentService.Add(comment);

            this.TempData[MainConstants.Success] = string.Format("Comment {0} added successfully!", model.Title);

            return this.RedirectToAction("Index", "Comments", new { area = "profile" });
        }
    }
}