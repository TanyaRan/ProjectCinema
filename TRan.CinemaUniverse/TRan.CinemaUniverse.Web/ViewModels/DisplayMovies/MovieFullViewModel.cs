using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;
using TRan.CinemaUniverse.Web.ViewModels.DisplayActors;

namespace TRan.CinemaUniverse.Web.ViewModels.DisplayMovies
{
    public class MovieFullViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        public string Award { get; set; }

        public string FilmingStory { get; set; }

        public IEnumerable<ActorViewModel> Actors { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Movie, MovieFullViewModel>()
                .ForMember(movieVM => movieVM.Genre, cfg => cfg.MapFrom(movie => movie.Genre.Name));
        }
    }
}