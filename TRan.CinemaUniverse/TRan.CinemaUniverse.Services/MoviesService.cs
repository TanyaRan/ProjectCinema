using System.Linq;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IEfDbSetWrapper<Movie> moviesWrapper;
        private readonly IEfSaveContext context;

        public MoviesService(IEfDbSetWrapper<Movie> moviesWrapper,
            IEfSaveContext context)
        {
            
            this.moviesWrapper = moviesWrapper;
            this.context = context;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.moviesWrapper.All;
        }

        public void Update(Movie movie)
        {
            this.moviesWrapper.Update(movie);
            this.context.Commit();
        }
    }
}
