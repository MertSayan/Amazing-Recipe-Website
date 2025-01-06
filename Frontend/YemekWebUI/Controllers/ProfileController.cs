using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı,Admin")]

    public class ProfileController : Controller
    {
        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.userId= userIdClaim.Value;
            ViewBag.Baslik = "Profil";
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            return View();
        }
    }
}
