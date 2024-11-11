using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
    public class _RecipeBannerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
