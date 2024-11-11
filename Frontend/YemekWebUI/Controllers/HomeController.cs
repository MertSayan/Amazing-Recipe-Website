using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }

    }
}
