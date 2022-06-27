using ApplicationCore.Contract.Repository;
using ApplicationCore.Entity;
using ApplicationCore.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public Task<Purchase> GetDetail(PurchaseRequestModel purchaseRequest, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> GetPurchasesDetail(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
