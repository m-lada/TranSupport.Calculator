namespace TranSupport.Calculator.Shared.Interfaces.Repositories;

public interface IRepository<IdType, TEntity>
        where TEntity : class
{
    Task<TEntity> GetByIdAsync(IdType id);

    Task<IList<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity item);

    Task<TEntity> UpdateAsync(TEntity item);

    Task DeleteAsync(IdType id);
}
