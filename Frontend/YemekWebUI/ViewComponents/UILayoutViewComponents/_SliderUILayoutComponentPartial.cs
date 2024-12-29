using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.UILayoutViewComponents
{
    public class _SliderUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(string baslik)
        {
            ViewBag.Baslik = baslik;    
            return View();
        }
    }
}
