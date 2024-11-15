using Microsoft.AspNetCore.Mvc;

namespace URL_Shorter.Server.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
