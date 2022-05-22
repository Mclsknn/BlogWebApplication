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
    public class EFWriterRepository : IWriterRepository
    {
        private BlogDbContext _dbContext;
        private EntityEntry entityEntry;
        private Writer writer;
        bool success = false;

        public EFWriterRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Writer writer)
        {
            writer.IsActive = true;
            entityEntry = await _dbContext.Writers.AddAsync(writer);
            success = entityEntry.State == EntityState.Added;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            writer = await _dbContext.Writers.FindAsync(id);
            entityEntry = _dbContext.Writers.Remove(writer);
            success = entityEntry.State == EntityState.Deleted;
            _dbContext.SaveChanges();
            return success;
        }

        public IList<Writer> GetAll()
        {
            return _dbContext.Writers.ToList();
        }

        public async Task<IList<Writer>> GetAllAsync()
        {
            var writers = await _dbContext.Writers.Where(x => x.IsActive == true).ToListAsync();
            return writers;
        }

        public async Task<Writer> GetByID(int id)
        {
            return await _dbContext.Writers.FindAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            writer = await _dbContext.Writers.FindAsync(id);
            writer.IsActive = false;
            entityEntry = _dbContext.Update(writer);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

        public bool Update(Writer writer)
        {

            entityEntry = _dbContext.Writers.Update(writer);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }
    }
}
