using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı,Admin")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Baslik = "Hakkımızda";
            return View();
        }
    }
}
