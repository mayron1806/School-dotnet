using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T : BaseModel
    {
        private readonly SchoolContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(SchoolContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> FindManyAsync(int limit, int page) {
            return await _dbSet.Skip(page * limit).Take(limit).AsNoTracking().ToListAsync<T>();
        }
        public async Task<T> FindByIdAsync(int id) {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.ID == id);
        }
        public virtual async Task<T> CreateAsync(T entity) {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity) {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity) {
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}