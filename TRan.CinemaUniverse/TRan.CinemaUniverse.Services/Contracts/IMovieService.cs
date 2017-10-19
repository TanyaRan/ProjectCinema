using System.Linq;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IMovieService
    {
        IQueryable<Movie> GetAll();

        void Add(Movie movie);

        void Update(Movie movie);
    }
}
