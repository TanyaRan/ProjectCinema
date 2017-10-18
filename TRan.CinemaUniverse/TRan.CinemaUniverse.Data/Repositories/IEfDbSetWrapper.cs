﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace TRan.CinemaUniverse.Data.Repositories
{
    public interface IEfDbSetWrapper<T>
        where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includeExpression);

        T GetById(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
