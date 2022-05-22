using BlogWebApplication.Business.Abstract;
using BlogWebApplication.DataAccess.Abstract;
using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Business.Concrete
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<bool> AddAsync(Blog blog)
        {
            return await _blogRepository.AddAsync(blog);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _blogRepository.DeleteAsync(id);
        }

        public async Task<IList<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByID(int id)
        {
            return await _blogRepository.GetByID(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _blogRepository.SoftDeleteAsync(id);
        }

        public bool Update(Blog blog)
        {
            return _blogRepository.Update(blog);
        }
    }
}
