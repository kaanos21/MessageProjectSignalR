using MessageProjectSignalR.Dtos.UserDtos;
using MessageProjectSignalR.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProjectSignalR.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            if (registerDto.Password == registerDto.ConfirmPassword)
            {
                var user = new AppUser()
                {
                    Name = registerDto.Name,
                    Surname = registerDto.Surname,
                    UserName = registerDto.UserName,
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    return View("dfşlkhmdfg");
                }
            }

            return View();
        }
    }
}
