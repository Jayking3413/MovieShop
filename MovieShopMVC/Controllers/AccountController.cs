using ApplicationCore.Contract.Service;
using ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
           var isVaildPassword = await _accountService.ValidateUser(model.Email, model.Password);
           if (isVaildPassword == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Surname, ""),
                    new Claim(ClaimTypes.GivenName, ""),
                    new Claim(ClaimTypes.NameIdentifier, ""),
                    new Claim(ClaimTypes.DateOfBirth, ""),
                    new Claim("Language", "English"),
                    new Claim(ClaimTypes.Country, "USA"),
                };
                return LocalRedirect("~/");
            }
           return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var user = await _accountService.RegisterUser(model);
            
            return RedirectToAction("Login");
        }
    }
}
