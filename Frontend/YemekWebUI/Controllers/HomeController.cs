﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Baslik = "Muhteşem yemek tarifleri";
           return View();
        }

    }
}
