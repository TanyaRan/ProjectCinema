using Bytes2you.Validation;
using System.Linq;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class MovieService : IMovieService
    {
        private readonly IEfDbSetWrapper<Movie> movieWrapper;
        private readonly IEfSaveContext context;

        public MovieService(IEfDbSetWrapper<Movie> movieWrapper,
            IEfSaveContext context)
        {
            Guard.WhenArgument(movieWrapper, "movieWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.movieWrapper = movieWrapper;
            this.context = context;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movieWrapper.All;
        }

        public void Add(Movie movie)
        {
            this.movieWrapper.Add(movie);
            this.context.Commit();
        }

        public void Update(Movie movie)
        {
            this.movieWrapper.Update(movie);
            this.context.Commit();
        }
    }
}
