using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/AdminMain")]
    [Authorize(Roles = "Admin")]
    public class AdminMainController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
