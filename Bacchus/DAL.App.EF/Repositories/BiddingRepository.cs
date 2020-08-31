using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.EF.Base.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BiddingRepository : BaseRepository<Bidding>, IBiddingRepository
    {
        public BiddingRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}