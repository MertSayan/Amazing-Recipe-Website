using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }
    }
}
