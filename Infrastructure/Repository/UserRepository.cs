using ApplicationCore.Contract.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Model;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Favorite> CheckFavorite(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfMoviePurchasedByUser(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> GetFavorites(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviews(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
