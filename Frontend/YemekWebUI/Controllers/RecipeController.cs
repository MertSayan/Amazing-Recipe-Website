using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
