using ApplicationCore.Contract.Respository;
using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public override Cast GetById(int id)
        {
            var castDetails = _dbContext.Casts
                .Include(x => x.MovieOfCast).ThenInclude(x => x.Movie)
                .FirstOrDefault(x => x.Id == id);
            return castDetails;
        }
    }
}
