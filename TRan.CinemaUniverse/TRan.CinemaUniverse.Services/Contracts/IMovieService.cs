using System;
using System.Linq;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IMovieService
    {
        IQueryable<Movie> GetAll();

        IQueryable<Movie> GetAllAndDeleted();

        IQueryable<Movie> GetDeleted();

        void Add(Movie movie);

        Movie GetById(Guid id);

        void Update(Movie movie);

        void Delete(Guid id);
    }
}
