using Bytes2you.Validation;
using System;
using System.Linq;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class ProjectionService : IProjectionService
    {
        private readonly IEfDbSetWrapper<Projection> projectionWrapper;
        private readonly IEfSaveContext context;

        public ProjectionService(IEfDbSetWrapper<Projection> projectionWrapper, IEfSaveContext context)
        {
            Guard.WhenArgument(projectionWrapper, "projectionWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.projectionWrapper = projectionWrapper;
            this.context = context;
        }

        public IQueryable<Projection> GetAll()
        {
            return this.projectionWrapper.All;
        }

        public IQueryable<Projection> GetAllAndDeleted()
        {
            return this.projectionWrapper.AllAndDeleted;
        }

        public IQueryable<Projection> GetDeleted()
        {
            return this.projectionWrapper.Deleted;
        }

        public void Add(Projection projection)
        {
            Guard.WhenArgument(projection, "projection").IsNull().Throw();

            this.projectionWrapper.Add(projection);
            this.context.Commit();
        }

        public Projection GetById(Guid id)
        {
            return this.projectionWrapper.GetById(id);
        }

        public void Update(Projection projection)
        {
            Guard.WhenArgument(projection, "projection").IsNull().Throw();

            this.projectionWrapper.Update(projection);
            this.context.Commit();
        }

        public void Delete(Guid id)
        {
            this.projectionWrapper.Delete(id);
            this.context.Commit();
        }
    }
}
