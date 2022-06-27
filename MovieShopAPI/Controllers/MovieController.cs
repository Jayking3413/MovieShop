using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [Route("top-grossing")]
        public async Task<IActionResult> GetTopGrossingMovies()
        {
            var movies = await _movieService.GetTopGrossingMovies();

            if (movies == null || !movies.Any())
            {
                // 404
                return NotFound(new { errorMessage = "No Movies Found" });
            }

            return Ok(movies);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound(new { errorMessage = $"No Movie Found for id: {id}" });
            }

            return Ok(movie);
        }
        [HttpGet]
        [Route("top-rated")]
        public async Task<IActionResult> GetTop30RatedMovies(int id)
        {
            var topRatedMovies = await _movieRepository.Get30HighestRatedMovies();

            if (topRatedMovies == null)
            {
                return NotFound(new { errorMessage = "No Movies Found" });
            }
            return Ok(topRatedMovies);
        }
    }
}
