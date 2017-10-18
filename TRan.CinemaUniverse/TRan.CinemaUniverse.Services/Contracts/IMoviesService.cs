using System.Linq;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IMoviesService
    {
        IQueryable<Movie> GetAll();
    }
}
