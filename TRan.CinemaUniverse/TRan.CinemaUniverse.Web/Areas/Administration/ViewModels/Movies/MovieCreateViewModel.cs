using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Movies
{
    public class MovieCreateViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(2500, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Director { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string StarActor { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string StarActress { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        public string FilmingStory { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Movie, MovieCreateViewModel>()
                .ForMember(movieVM => movieVM.Genre, cfg => cfg.MapFrom(movie => movie.Genre.Name));
        }
    }
}