using BrasilGeo.Domain.Entities;

namespace BrasilGeo.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync (long id);
        Task SaveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
