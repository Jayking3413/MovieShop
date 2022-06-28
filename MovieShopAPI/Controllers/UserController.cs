using ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //[Route("details")]
        //public async Task<IActionResult> GetUserDetails(int id)
        //{
        //    var userDetails = await _userService.GetUserDetails(id);

        //    if (userDetails == null)
        //    {
        //        return NotFound(new { errorMessage = $"No Movie Found for id: {id}" });
        //    }
        //    return Ok(userDetails);
        //}

        //[HttpPost]
        //[Route("purchase-movie")]
        //public async Task<IActionResult> purchaseMovies(PurchaseRequestModel purchaseRequest, int userId)
        //{
        //    var purchaseMovie = await _purchaseRepository.GetDetail(purchaseRequest, userId);
        //}
    }
}
