using System;

namespace Contracts.DAL.Base.Helpers
{
    public interface IRepositoryFactory
    {
        Func<IDataContext, object> GetRepositoryFactory<TRepo>();

        Func<IDataContext, object> GetRepositoryFactoryForEntity<TEntity>()
            where TEntity : class, IBaseEntity, new();
    }
}