using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Movies
{
    public class MovieCreateViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(2500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Director { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string ImageUrl { get; set; }

        public string GenreId { get; set; }
        public IEnumerable<SelectListItem> GenresList { get; set; }

        public string StarActorId { get; set; }
        public IEnumerable<SelectListItem> ActorsList { get; set; }

        public string StarActressId { get; set; }
        public IEnumerable<SelectListItem> ActressesList { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string FilmingStory { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Movie, MovieCreateViewModel>()
                .ForMember(movieVM => movieVM.GenreId, cfg => cfg.MapFrom(movie => movie.Genre.Id))
                .ForMember(movieVM => movieVM.StarActorId, cfg => cfg.MapFrom(movie => movie.StarActor.Id))
                .ForMember(movieVM => movieVM.StarActressId, cfg => cfg.MapFrom(movie => movie.StarActress.Id));
        }
    }
}