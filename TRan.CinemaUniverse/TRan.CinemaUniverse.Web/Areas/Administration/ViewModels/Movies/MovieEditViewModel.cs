using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Movies
{
    public class MovieEditViewModel : IMapFrom<Movie>
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(2500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string ImageUrl { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string FilmingStory { get; set; }
    }
}