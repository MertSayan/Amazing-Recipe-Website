using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.HomeViewComponents
{
    public class _DiscoverRecipesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
