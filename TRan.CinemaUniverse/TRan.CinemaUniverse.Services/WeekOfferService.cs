using Bytes2you.Validation;
using System;
using System.Linq;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class WeekOfferService : IWeekOfferService
    {
        private readonly IEfDbSetWrapper<WeekOffer> weekOfferWrapper;
        private readonly IEfSaveContext context;

        public WeekOfferService(IEfDbSetWrapper<WeekOffer> weekOfferWrapper, IEfSaveContext context)
        {
            Guard.WhenArgument(weekOfferWrapper, "weekOfferWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.weekOfferWrapper = weekOfferWrapper;
            this.context = context;
        }

        public IQueryable<WeekOffer> GetAll()
        {
            return this.weekOfferWrapper.All;
        }

        public IQueryable<WeekOffer> GetAllAndDeleted()
        {
            return this.weekOfferWrapper.AllAndDeleted;
        }

        public IQueryable<WeekOffer> GetDeleted()
        {
            return this.weekOfferWrapper.Deleted;
        }

        public void Add(WeekOffer weekOffer)
        {
            Guard.WhenArgument(weekOffer, "weekOffer").IsNull().Throw();

            this.weekOfferWrapper.Add(weekOffer);
            this.context.Commit();
        }

        public WeekOffer GetById(Guid id)
        {
            return this.weekOfferWrapper.GetById(id);
        }

        public void Update(WeekOffer weekOffer)
        {
            Guard.WhenArgument(weekOffer, "weekOffer").IsNull().Throw();

            this.weekOfferWrapper.Update(weekOffer);
            this.context.Commit();
        }

        public void Delete(Guid id)
        {
            this.weekOfferWrapper.Delete(id);
            this.context.Commit();
        }
    }
}
