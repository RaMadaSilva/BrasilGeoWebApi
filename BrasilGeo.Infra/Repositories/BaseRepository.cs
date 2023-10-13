using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Repositories;
using BrasilGeo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BrasilGeo.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BrazilGeoContext _context;
        private readonly DbSet<TEntity> _set;

        public BaseRepository(BrazilGeoContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public  async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            await Task.CompletedTask; 
            return _set.AsNoTracking().ToList(); 
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
          return await _set.FindAsync(id);
        }

        public async Task SaveAsync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.CompletedTask; 
            _set.Entry(entity).State = EntityState.Modified;
          
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.CompletedTask; 
            _set.Remove(entity); 
        }
    }
}
