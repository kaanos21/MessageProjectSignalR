using Microsoft.AspNetCore.Mvc;

namespace MessageProjectSignalR.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Defaulto()
        {
            return View();
        }
    }
}
