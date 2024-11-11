using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
