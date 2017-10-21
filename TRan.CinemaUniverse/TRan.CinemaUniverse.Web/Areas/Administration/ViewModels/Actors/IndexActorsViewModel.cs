using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Actors
{
    public class IndexActorsViewModel : IMapFrom<Actor>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}