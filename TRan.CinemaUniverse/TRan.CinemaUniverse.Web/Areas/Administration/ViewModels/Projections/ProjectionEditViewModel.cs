using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Projections
{
    public class ProjectionEditViewModel : IMapFrom<Projection>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Day { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
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