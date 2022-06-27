using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Service;
using ApplicationCore.Entity;
using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Favorite> _favoriteRepository;
        private readonly IRepository<Review> _reviewRepository;

        public UserService(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public UserService(IRepository<Favorite> favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var newFavorite = new Favorite
            {
                Id = favoriteRequest.Id,
                MovieId = favoriteRequest.MovieId,
                UserId = favoriteRequest.UserId
            };
            var addFavorite = await _favoriteRepository.Add(newFavorite);
        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var newReview = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };
            var addReview = _reviewRepository.Add(newReview);
        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            var favoriteExits = await _userRepository.CheckFavorite(id, movieId);
            if (favoriteExits == null)
            {
                throw new Exception("Do you want to add to your Favorite List?");
            }
            return true;
        }

        public async Task<FavoriteModel> GetAllFavoritesForUser(int id)
        {
            var allFavorites = await _favoriteRepository.GetById(id);
            var favoriteModel = new FavoriteModel
            {
                Id = allFavorites.Id,
                UserId = allFavorites.UserId,
                MovieId = allFavorites.MovieId
            };
            return favoriteModel;
        }

        public async Task<PurchaseModel> GetAllPurchasesForUser(int id)
        {
            var allPurchases = await _purchaseRepository.GetById(id);
            var purchaseModel = new PurchaseModel
            {
                Id = allPurchases.Id,
                UerId = allPurchases.UserId,
                MovieId = allPurchases.MovieId
            };
            return purchaseModel;
        }

        public async Task<ReviewModel> GetAllReviewsByUser(int id)
        {
            var allReviews = await _reviewRepository.GetById(id);
            var reviewModel = new ReviewModel
            {
                MovieId = allReviews.MovieId,
                UserId = allReviews.UserId,
                Rating = allReviews.Rating,
                ReviewText = allReviews.ReviewText
            };
            return reviewModel;
        }

        public async Task GetPurchasesDetails(int userId, int movieId)
        {
            
            var purchaseDetails = new List<PurchaseModel>();

            foreach (var purchase in purchaseDetails)
            {
                purchaseDetails.Add(new PurchaseModel
                {
                    Id = purchase.Id,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    TotalPrice = purchase.TotalPrice,
                    PurchaseNumber = purchase.PurchaseNumber
                });
            }
            var details = await _purchaseRepository.GetPurchasesDetail(userId, movieId);

        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var moviePurchased = await _purchaseRepository.GetDetail(purchaseRequest, userId);
            if (moviePurchased == null)
            {
                throw new Exception("You can watch it after purchased!");
            }
            return true;
        }

        public async Task PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchaseMovie = await _purchaseRepository.GetDetail(purchaseRequest, userId);
            if (purchaseMovie == null)
            {
                throw new Exception("You can watch it after purchased!");
            }

        }
        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var getReview = await _userRepository.GetReviews(userId, movieId);
            if (getReview == null)
            {
                throw new Exception("Please write a review for the movie");
            }
            var deleteReview = _reviewRepository.Delete(getReview);
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {

            var getFavorite = await _userRepository.GetFavorites(favoriteRequest);
            if (getFavorite == null)
            {
                throw new Exception("The movie is not in your favorite list");
            }
            var deleteFavorite = _favoriteRepository.Delete(getFavorite);
        }

        public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            var reviews = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };

            var updateReview = _reviewRepository.Update(reviews);
        }
    }
}
