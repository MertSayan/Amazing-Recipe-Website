using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.UILayoutViewComponents
{
    public class _SliderUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
