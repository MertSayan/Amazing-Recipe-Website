using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.UILayoutViewComponents
{
    public class _DiscoverRecipesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
