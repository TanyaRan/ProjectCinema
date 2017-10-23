using System;
using System.ComponentModel.DataAnnotations;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Actors
{
    public class ActorEditViewModel : IMapFrom<Actor>
    {
        public Guid Id { get; set; }

        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(300, MinimumLength = 3)]
        public string ImageUrl { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        public string Filmography { get; set; }
    }
}