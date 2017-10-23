using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;

namespace TRan.CinemaUniverse.Services
{
    public class UserService : IUserService
    {
        private readonly IEfDbSetWrapper<User> userWrapper;
        private readonly IEfSaveContext context;

        public UserService(IEfDbSetWrapper<User> userWrapper, IEfSaveContext context)
        {
            Guard.WhenArgument(userWrapper, "userWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.userWrapper = userWrapper;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.userWrapper.All;
        }

        public IQueryable<User> GetAllAndDeleted()
        {
            return this.userWrapper.AllAndDeleted;
        }

        public IQueryable<User> GetDeleted()
        {
            return this.userWrapper.Deleted;
        }
 
        public void Add(User user)
        {
            Guard.WhenArgument(user, "user").IsNull().Throw();

            this.userWrapper.Add(user);
            this.context.Commit();
        }
 
        public User GetById(Guid id)
        {
            return this.userWrapper.GetById(id);
        }
 
        public void Update(User user)
        {
            Guard.WhenArgument(user, "user").IsNull().Throw();

            this.userWrapper.Update(user);
            this.context.Commit();
        }

        public void Delete(Guid id)
        {
            this.userWrapper.Delete(id);
            this.context.Commit();
        }
    }
}
