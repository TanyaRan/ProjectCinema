using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Profile.ViewModels.Comments
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Author { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(800, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        //[Required]
        //public Guid ProjectionId { get; set; }

        //public virtual Projection Projection { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(commentVM => commentVM.Author, cfg => cfg.MapFrom(comment => comment.Author.UserName));
        }
    }
}