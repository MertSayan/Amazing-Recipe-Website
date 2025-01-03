﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Printing;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Recipe")]
    public class RecipeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RecipeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async  Task<IActionResult> Index(int pageNumber=1,int pageSize=3)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7092/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllRecipeForAdminDto>>(jsonData);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                return View(values);
            }
            return View();
        }

        [Route("RemoveRecipe/{id}")]
        public async Task<IActionResult> RemoveRecipe(int id)
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7092/api/Recipe?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Recipe", new {area="Admin"});
            }
            return View();
        }

    }
}
