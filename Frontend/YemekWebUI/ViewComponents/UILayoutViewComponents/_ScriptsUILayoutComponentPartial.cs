using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
