using ApplicationCore.Entity;
using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repository
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<Purchase> GetPurchasesDetail(int userId, int movieId);

        Task<Purchase> GetDetail(PurchaseRequestModel purchaseRequest, int userId);
    }
}
