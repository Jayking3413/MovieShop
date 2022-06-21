using ApplicationCore.Contract.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            // linQ code to get to 30
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;

        }

        public IEnumerable<Movie> Get30HighestRatedMovies()
        {
            throw new NotImplementedException();
        }

        public override Movie GetById(int id)
        {
            var movieDetails = _dbContext.Movies
                .Include(x => x.GenreMovie).ThenInclude(x => x.Genre)
                .Include(x => x.Trailers)
                .Include(x => x.movieOfCasts).ThenInclude(x => x.Cast)
                .Include(x => x.Purchase)
                .Include(x => x.Reviews)
                .FirstOrDefault(x => x.Id == id);
            return movieDetails;
        }
    }
}
