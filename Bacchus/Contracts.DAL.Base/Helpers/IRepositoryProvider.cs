using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base.Helpers
{
    public interface IRepositoryProvider
    {
        TRepository GetRepository<TRepository>();

        IBaseRepositoryAsync<TEntity> GetRepositoryForEntity<TEntity>()
            where TEntity : class, IBaseEntity, new();
    }
}