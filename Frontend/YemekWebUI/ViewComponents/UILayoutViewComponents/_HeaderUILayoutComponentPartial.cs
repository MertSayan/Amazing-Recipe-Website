using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
