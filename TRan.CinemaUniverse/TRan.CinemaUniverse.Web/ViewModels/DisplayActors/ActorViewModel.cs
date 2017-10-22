using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.ViewModels.DisplayActors
{
    public class ActorViewModel : IMapFrom<Actor>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}