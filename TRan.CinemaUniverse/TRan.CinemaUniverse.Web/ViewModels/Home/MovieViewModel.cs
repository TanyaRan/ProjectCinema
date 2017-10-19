using AutoMapper;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.ViewModels.Home
{
    public class MovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        // public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(movieVM => movieVM.Genre, cfg => cfg.MapFrom(movie => movie.Genre.Name));
        }
    }
}