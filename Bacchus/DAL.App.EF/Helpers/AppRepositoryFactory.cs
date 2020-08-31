using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.EF.Base.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory
    {
        public AppRepositoryFactory()
        {
            RepositoryCreationMethods.Add(typeof(IBiddingRepository), dataContext 
                => new BiddingRepository(dataContext));
        }
    }
}