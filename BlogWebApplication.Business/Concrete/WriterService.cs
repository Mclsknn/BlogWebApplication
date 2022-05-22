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
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        public WriterService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }
        public async Task<bool> AddAsync(Writer writer)
        {
            return await _writerRepository.AddAsync(writer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _writerRepository.DeleteAsync(id);
        }

        public async Task<IList<Writer>> GetAllAsync()
        {
            return await _writerRepository.GetAllAsync();
        }

        public async Task<Writer> GetByID(int id)
        {
            return await _writerRepository.GetByID(id);
        }

        public IList<Writer> GetWriters()
        {
            return _writerRepository.GetAll();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _writerRepository.SoftDeleteAsync(id);
        }

        public bool Update(Writer writer)
        {
            return _writerRepository.Update(writer);
        }
    }
}
