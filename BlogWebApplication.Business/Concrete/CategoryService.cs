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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> AddAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByID(int id)
        {
            return await _categoryRepository.GetByID(id);
        }

        public IList<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _categoryRepository.SoftDeleteAsync(id);
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
    }
}
