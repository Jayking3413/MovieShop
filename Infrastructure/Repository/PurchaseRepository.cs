using ApplicationCore.Contract.Repository;
using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public Task<Purchase> Add(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Delete(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Update(Purchase entity)
        {
            throw new NotImplementedException();
        }
    }
}
