using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.RecipeDetailViewComponents
{
    public class _RecipeDetailBannerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
