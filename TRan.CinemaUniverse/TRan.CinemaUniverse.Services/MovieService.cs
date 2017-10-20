using Bytes2you.Validation;
using System;
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

        public IQueryable<Movie> GetAllAndDeleted()
        {
            return this.movieWrapper.AllAndDeleted;
        }

        public IQueryable<Movie> GetDeleted()
        {
            return this.movieWrapper.Deleted;
        }

        public void Add(Movie movie)
        {
            Guard.WhenArgument(movie, "movie").IsNull().Throw();

            this.movieWrapper.Add(movie);
            this.context.Commit();
        }

        public Movie GetById(Guid id)
        {
            return this.movieWrapper.GetById(id);
        }

        public void Update(Movie movie)
        {
            Guard.WhenArgument(movie, "movie").IsNull().Throw();

            this.movieWrapper.Update(movie);
            this.context.Commit();
        }

        public void Delete(Guid id)
        {
            this.movieWrapper.Delete(id);
            this.context.Commit();
        }
    }
}
