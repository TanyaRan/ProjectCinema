using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IEfDbSetWrapper<Movie> moviesWrapper;

        public MoviesService(IEfDbSetWrapper<Movie> moviesWrapper)
        {
            this.moviesWrapper = moviesWrapper;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.moviesWrapper.All;
        }
    }
}
