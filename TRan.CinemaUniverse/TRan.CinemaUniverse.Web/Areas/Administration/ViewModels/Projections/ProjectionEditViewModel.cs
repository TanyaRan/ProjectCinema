using System;
using AutoMapper;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Projections
{
    public class ProjectionEditViewModel : IMapFrom<Projection>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public DateTime Day { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Range(100, 180)]
        public int Duration { get; set; }

        public string MovieTitle { get; set; }

        public string MovieUrl { get; set; }

        public string LecturerName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Projection, ProjectionEditViewModel>()
                .ForMember(projVM => projVM.MovieTitle, cfg => cfg.MapFrom(proj => proj.Movie.Title))
                .ForMember(projVM => projVM.MovieUrl, cfg => cfg.MapFrom(proj => proj.Movie.ImageUrl))
                .ForMember(projVM => projVM.LecturerName, cfg => cfg.MapFrom(proj => proj.Lecturer.UserName));
        }
    }
}