using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Recipe")]
    public class RecipeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
