using System;
using System.Linq;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IProjectionService
    {
        IQueryable<Projection> GetAll();

        IQueryable<Projection> GetAllAndDeleted();

        IQueryable<Projection> GetDeleted();

        void Add(Projection projection);

        Projection GetById(Guid id);

        void Update(Projection projection);

        void Delete(Guid id);
    }
}
