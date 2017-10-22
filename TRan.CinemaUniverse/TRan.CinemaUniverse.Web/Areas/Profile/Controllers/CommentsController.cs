using AutoMapper;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Index()
        {
            return View();
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
            }
            
            this.commentService.Add(comment);

            this.TempData[MainConstants.Success] = string.Format("Comment {0} added successfully!", model.Title);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}