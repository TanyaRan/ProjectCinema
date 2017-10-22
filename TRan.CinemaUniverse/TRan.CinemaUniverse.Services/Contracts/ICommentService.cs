using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.Contracts
{
    public interface ICommentService
    {
        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetAllAndDeleted();

        IQueryable<Comment> GetDeleted();

        void Add(Comment comment);

        Comment GetById(Guid id);

        void Update(Comment comment);

        void Delete(Guid id);
    }
}
