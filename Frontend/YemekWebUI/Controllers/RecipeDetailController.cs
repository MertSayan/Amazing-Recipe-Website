using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı")]
    public class RecipeDetailController : Controller
    {
        public IActionResult Index(int recipeId)
        {
            ViewBag.Baslik = "Tarif Detayı";
            ViewBag.recipeId = recipeId;
            return View();
        }
    }
}
