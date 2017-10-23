using System;
using AutoMapper;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Projections
{
    public class ProjectionCreateViewModel : IMapFrom<Projection>, IHaveCustomMappings
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Range(100, 180)]
        [DataType(DataType.Duration)]
        public int Duration { get; set; }

        [Required]
        public string MovieId { get; set; }
        public IEnumerable<SelectListItem> MoviesList { get; set; }

        public string LecturerName { get; set; }
        // public string LecturerId { get; set; }
        // public IEnumerable<SelectListItem> LecturersList { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Projection, ProjectionCreateViewModel>()
                .ForMember(projVM => projVM.MovieId, cfg => cfg.MapFrom(proj => proj.Movie.Id))
                .ForMember(projVM => projVM.LecturerName, cfg => cfg.MapFrom(proj => proj.Lecturer.UserName));
        }
    }
}