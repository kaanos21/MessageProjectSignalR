using MessageProjectSignalR.Dtos.UserDtos;
using MessageProjectSignalR.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProjectSignalR.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result= await _signInManager.PasswordSignInAsync(loginDto.UserName,loginDto.Password,false,false);
            if(result.Succeeded)
            {
                return RedirectToAction("Defaulto", "Default");
            }
            return View();
        }
    }
}
