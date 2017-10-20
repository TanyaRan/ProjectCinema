using System;
using System.Linq;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IWeekOfferService
    {
        IQueryable<WeekOffer> GetAll();

        IQueryable<WeekOffer> GetAllAndDeleted();

        IQueryable<WeekOffer> GetDeleted();

        void Add(WeekOffer weekOffer);

        WeekOffer GetById(Guid id);

        void Update(WeekOffer weekOffer);

        void Delete(Guid id);
    }
}
