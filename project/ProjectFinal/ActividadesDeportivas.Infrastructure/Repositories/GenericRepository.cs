using System.Collections.Generic;
using System.Threading.Tasks;
using ActividadesDeportivas.Infrastructure.Context;
using ActividadesDeportivas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActividadesDeportivas.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ActividadesDbContext _context;

        public GenericRepository(ActividadesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Set<T>().FindAsync(id) != null;
    }
}
