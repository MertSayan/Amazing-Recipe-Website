using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSideBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
