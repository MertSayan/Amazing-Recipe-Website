using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.HomeViewComponents
{
    public class _RecipeServiceComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
