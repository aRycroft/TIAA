using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
