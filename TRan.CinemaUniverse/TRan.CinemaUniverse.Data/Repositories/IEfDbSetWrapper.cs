using System;
using System.Linq;
using System.Linq.Expressions;
using TRan.CinemaUniverse.Models.Contracts;

namespace TRan.CinemaUniverse.Data.Repositories
{
    public interface IEfDbSetWrapper<T>
        where T : class, IDeletable
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        IQueryable<T> Deleted { get; }

        T GetById(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(Guid id);
    }
}
