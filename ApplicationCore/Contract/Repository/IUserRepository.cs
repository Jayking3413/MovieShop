using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace ApplicationCore.Contract.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<bool> CheckIfMoviePurchasedByUser(int userId, int movieId);
        Task<Favorite> GetFavorites(FavoriteRequestModel favoriteRequest);
        Task<Review> GetReviews(int userId, int movieId);
        Task<Favorite> CheckFavorite (int id, int movieId);
    }
}
