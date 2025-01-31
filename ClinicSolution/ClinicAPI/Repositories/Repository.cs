using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ClinicAPI.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected readonly ClinicContext _context;

        protected Repository(ClinicContext context) { 
            _context = context;
        }

        public abstract Task<T> Get(K key);
       
        public abstract Task<IEnumerable<T>> GetAll();
       
        public async Task<T> Add(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(K key)
        {
            var entity = await Get(key);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
       
        public async Task<T> Update(T entity)
        {
           _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
