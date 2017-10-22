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
    public class CommentService : ICommentService
    {
        private readonly IEfDbSetWrapper<Comment> commentWrapper;
        private readonly IEfSaveContext context;

        public CommentService(IEfDbSetWrapper<Comment> commentWrapper, IEfSaveContext context)
        {
            Guard.WhenArgument(commentWrapper, "commentWrapper").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.commentWrapper = commentWrapper;
            this.context = context;
        }

        public IQueryable<Comment> GetAll()
        {
            return this.commentWrapper.All;
        }

        public IQueryable<Comment> GetAllAndDeleted()
        {
            return this.commentWrapper.AllAndDeleted;
        }

        public IQueryable<Comment> GetDeleted()
        {
            return this.commentWrapper.Deleted;
        }

        public void Add(Comment comment)
        {
            Guard.WhenArgument(comment, "comment").IsNull().Throw();

            this.commentWrapper.Add(comment);
            this.context.Commit();
        }

        public Comment GetById(Guid id)
        {
            return this.commentWrapper.GetById(id);
        }

        public void Update(Comment comment)
        {
            Guard.WhenArgument(comment, "comment").IsNull().Throw();

            this.commentWrapper.Update(comment);
            this.context.Commit();
        }

        public void Delete(Guid id)
        {
            this.commentWrapper.Delete(id);
            this.context.Commit();
        }
    }
}
