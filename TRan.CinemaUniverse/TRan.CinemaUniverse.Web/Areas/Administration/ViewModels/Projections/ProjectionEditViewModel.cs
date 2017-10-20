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

        [Required]
        public DateTime Day { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Range(100, 180)]
        public int Duration { get; set; }

        [Required]
        public string Movie { get; set; }

        [Required]
        public string Lecturer { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Projection, ProjectionEditViewModel>()
                .ForMember(projVM => projVM.Movie, cfg => cfg.MapFrom(proj => proj.Movie.Title))
                .ForMember(projVM => projVM.Lecturer, cfg => cfg.MapFrom(proj => proj.Lecturer.UserName));
        }
    }
}