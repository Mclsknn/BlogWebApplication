using BlogWebApplication.DataAccess.Abstract;
using BlogWebApplication.DataAccess.Context;
using BlogWebApplicationEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Concrete.EntityFramework
{
    public class EFBlogRepository : IBlogRepository
    {
        private BlogDbContext _dbContext;
        private EntityEntry entityEntry;
        private Blog blog;
        bool success = false;

        public EFBlogRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Blog blog)
        {
            blog.IsActive = true;
            entityEntry = await _dbContext.Blogs.AddAsync(blog);
            success = entityEntry.State == EntityState.Added;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            blog = await _dbContext.Blogs.FindAsync(id);
            entityEntry = _dbContext.Blogs.Remove(blog);
            success = entityEntry.State == EntityState.Deleted;
            _dbContext.SaveChanges();
            return success;
        }

        public List<Blog> GetAll()
        {
            return _dbContext.Blogs.ToList();
        }

        public async Task<IList<Blog>> GetAllAsync()
        {
            var products = await _dbContext.Blogs.Where(x=> x.IsActive == true).Include(b=> b.Writer).Include(c=> c.Category).ToListAsync();
            return products;               
        }

        public async Task<Blog> GetByID(int id)
        {
            return await _dbContext.Blogs.FindAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            blog = await _dbContext.Blogs.FindAsync(id);
            blog.IsActive = false;
            entityEntry = _dbContext.Update(blog);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

        public bool Update(Blog blog)
        {
            entityEntry = _dbContext.Update(blog);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }
    }
}
