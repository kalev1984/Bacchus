using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepositoryProvider _repositoryProvider;

        public AppUnitOfWork(AppDbContext appDbContext, IRepositoryProvider repositoryProvider)
        {
            _appDbContext = appDbContext;
            _repositoryProvider = repositoryProvider;
        }

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public IBaseRepositoryAsync<TEntity> BaseRepository<TEntity>() where TEntity : class, IBaseEntity, new() =>
            _repositoryProvider.GetRepositoryForEntity<TEntity>();

        public IBiddingRepository Biddings => 
            _repositoryProvider.GetRepository<IBiddingRepository>();
    }
}