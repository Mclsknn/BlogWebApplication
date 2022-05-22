using BlogWebApplication.DataAccess.Abstract;
using BlogWebApplication.DataAccess.Context;
using BlogWebApplicationEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Concrete.EntityFramework
{
    public class EFCommentRepository : ICommentRepository
    {
        public BlogDbContext _dbContext;
        public EFCommentRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> AddAsync(Comment t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Comment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetCommentsByBlogID(int BlogID)
        {
            return _dbContext.Comments.Where(x => x.BlogID == BlogID).Include(y => y.User).ToList();
        }

        public Task<bool> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
