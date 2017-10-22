using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Models.Contracts;

namespace TRan.CinemaUniverse.Data
{
    public class CinemaSqlDbContext : IdentityDbContext<User>
    {
        public CinemaSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Movie> Movies { get; set; }
        public IDbSet<Actor> Actors { get; set; }
        public IDbSet<Projection> Projections { get; set; }
        public IDbSet<WeekOffer> WeekOffers { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable &&
                        ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static CinemaSqlDbContext Create()
        {
            return new CinemaSqlDbContext();
        }
    }
}
