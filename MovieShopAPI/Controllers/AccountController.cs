using ApplicationCore.Contract.Service;
using ApplicationCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var user = await _accountService.RegisterUser(model);
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string eamil, string password)
        {
            var signIn = await _accountService.ValidateUser(eamil, password);
            
            return Ok(signIn);
        }

        //[HttpGet]
        //[Route("check-email")]
        //public async Task<IActionResult> checkEmail(string email)
        //{
        //    var emails = await _accountService.GetUserByEmail(email);
        //    return Ok(email);
        //}
    }
}
