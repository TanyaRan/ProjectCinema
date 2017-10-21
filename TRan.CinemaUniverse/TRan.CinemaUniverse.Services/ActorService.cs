using Bytes2you.Validation;
using System;
using System.Linq;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class ActorService : IActorService
    {
        private readonly IEfDbSetWrapper<Actor> actorWrapper;
        private readonly IEfSaveContext context;

        public ActorService(IEfDbSetWrapper<Actor> actorWrapper, IEfSaveContext context)
        {
            Guard.WhenArgument(actorWrapper, "actorWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.actorWrapper = actorWrapper;
            this.context = context;
        }

        public IQueryable<Actor> GetAll()
        {
            return this.actorWrapper.All;
        }

        public IQueryable<Actor> GetAllAndDeleted()
        {
            return this.actorWrapper.AllAndDeleted;
        }

        public IQueryable<Actor> GetDeleted()
        {
            return this.actorWrapper.Deleted;
        }

        public void Add(Actor actor)
        {
            Guard.WhenArgument(actor, "actor").IsNull().Throw();

            this.actorWrapper.Add(actor);
            this.context.Commit();
        }

        public Actor GetById(Guid id)
        {
            return this.actorWrapper.GetById(id);
        }

        public void Update(Actor actor)
        {
            Guard.WhenArgument(actor, "actor").IsNull().Throw();

            this.actorWrapper.Update(actor);
            this.context.Commit();
        }

        public void Delete(Guid id)
        {
            this.actorWrapper.Delete(id);
            this.context.Commit();
        }
    }
}
