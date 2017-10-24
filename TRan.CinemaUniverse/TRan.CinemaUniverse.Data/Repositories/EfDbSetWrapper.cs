using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using TRan.CinemaUniverse.Models.Contracts;

namespace TRan.CinemaUniverse.Data.Repositories
{
    public class EfDbSetWrapper<T> : IEfDbSetWrapper<T>
        where T : class , IDeletable
    {
        private readonly CinemaSqlDbContext context;

        public EfDbSetWrapper(CinemaSqlDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All
        {
            get
            {
                return this.context.Set<T>()
                    .Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> AllAndDeleted
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public IQueryable<T> Deleted
        {
            get
            {
                return this.context.Set<T>()
                    .Where(x => x.IsDeleted);
            }
        }

        public T GetById(Guid id)
        {
            var item = this.context.Set<T>().Find(id);
            if (item.IsDeleted)
            {
                return null;
            }

            return item;
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.context.Set<T>().Add(entity);
            }
        }       

        public void Update(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            Update(entity);
        }
    }
}
