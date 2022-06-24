using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Favorite()
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

    }
}
