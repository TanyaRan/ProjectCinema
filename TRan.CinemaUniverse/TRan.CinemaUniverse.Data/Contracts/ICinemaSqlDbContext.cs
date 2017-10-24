using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Data.Contracts
{
    public interface ICinemaSqlDbContext
    {
        IDbSet<Genre> Genres { get; set; }
        IDbSet<Movie> Movies { get; set; }
        IDbSet<Actor> Actors { get; set; }
        IDbSet<Projection> Projections { get; set; }
        IDbSet<WeekOffer> WeekOffers { get; set; }
        IDbSet<Comment> Comments { get; set; }
    }
}
