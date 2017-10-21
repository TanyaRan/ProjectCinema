using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IActorService
    {
        IQueryable<Actor> GetAll();

        IQueryable<Actor> GetAllAndDeleted();

        IQueryable<Actor> GetDeleted();

        void Add(Actor actor);

        Actor GetById(Guid id);

        void Update(Actor actor);

        void Delete(Guid id);
    }
}
