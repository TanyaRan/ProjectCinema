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
    public class MovieEditViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Director { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string StarActor { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string StarActress { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string FilmingStory { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Movie, MovieEditViewModel>()
                .ForMember(movieVM => movieVM.Genre, cfg => cfg.MapFrom(movie => movie.Genre.Name));
        }
    }
}