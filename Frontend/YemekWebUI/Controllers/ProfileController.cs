using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı")]

    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.userId= userIdClaim.Value;

            return View();
        }
    }
}
