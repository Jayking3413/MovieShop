using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    [Authorize] // Filter check the user is authentic or not
    public class UserController : Controller
    {
        private readonly ICurrentLogedInUser _currentLogedInUser;

        public UserController(ICurrentLogedInUser currentLogedInUser)
        {
            _currentLogedInUser = currentLogedInUser;
        }
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            //var cookie = this.HttpContext.Request.Cookies["MovieShopAuthCookie"]; create service instead
            var userId =  _currentLogedInUser.UserId;
            // use the UserId and send to User Serivce to get information for that User 
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFavorite()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReview()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyMovie()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

    }
}
