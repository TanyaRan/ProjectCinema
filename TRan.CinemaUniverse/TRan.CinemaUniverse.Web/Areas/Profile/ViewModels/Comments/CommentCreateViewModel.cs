using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Profile.ViewModels.Comments
{
    public class CommentCreateViewModel : IMapFrom<Comment>
    {
        //public string AuthorId { get; set; }

        //public virtual User Author { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(800, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        //[Required]
        //public Guid ProjectionId { get; set; }

        //public virtual Projection Projection { get; set; }
    }
}