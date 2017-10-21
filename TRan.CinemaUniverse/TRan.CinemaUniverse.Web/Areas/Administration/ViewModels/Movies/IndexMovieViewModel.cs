using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Actors;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Movies
{
    public class IndexMovieViewModel : IMapFrom<Movie>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<IndexActorsViewModel> Actors { get; set; }
    }
}