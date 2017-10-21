using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Actors
{
    public class ActorEditViewModel : IMapFrom<Actor>
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string ImageUrl { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        public string Filmography { get; set; }
    }
}