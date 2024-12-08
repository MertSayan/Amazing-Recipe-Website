using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminFooterLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
