using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IGenreService
    {
        IQueryable<Genre> GetAll();

        void Add(Genre genre);

        void Update(Genre genre);
    }
}
