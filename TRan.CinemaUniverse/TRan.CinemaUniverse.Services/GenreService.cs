using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEfDbSetWrapper<Genre> genreWrapper;
        private readonly IEfSaveContext context;

        public GenreService(IEfDbSetWrapper<Genre> genreWrapper, IEfSaveContext context)
        {
            Guard.WhenArgument(genreWrapper, "genreWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.genreWrapper = genreWrapper;
            this.context = context;
        }

        public IQueryable<Genre> GetAll()
        {
            return this.genreWrapper.All;
        }

        public void Add(Genre genre)
        {
            this.genreWrapper.Add(genre);
            this.context.Commit();
        }

        public void Update(Genre genre)
        {
            this.genreWrapper.Update(genre);
            this.context.Commit();
        }
    }
}
