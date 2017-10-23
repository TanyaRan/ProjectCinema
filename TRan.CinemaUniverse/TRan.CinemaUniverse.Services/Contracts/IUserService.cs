using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllAndDeleted();

        IQueryable<User> GetDeleted();

        void Add(User user);

        User GetById(Guid id);

        void Update(User user);

        void Delete(Guid id);
    }
}
