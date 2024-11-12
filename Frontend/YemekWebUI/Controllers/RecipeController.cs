using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using YemekUygulamasıDto.RecipeDtos;
using System.Text;

namespace YemekWebUI.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RecipeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRecipe(CreateRecipeDto createRecipeDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createRecipeDto);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync($"https://localhost:7092/api/Recipe?Title=deneme1&Description=q&CategoryId=1&UserId=3&MaterialIds=2");

            var client = _httpClientFactory.CreateClient();

            // Form verisi hazırlıyoruz
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(createRecipeDto.Title), "Title");
            formData.Add(new StringContent(createRecipeDto.Description), "Description");
            formData.Add(new StringContent(createRecipeDto.CategoryId.ToString()), "CategoryId");

            //jwt token dan alacağım.
            formData.Add(new StringContent(3.ToString()), "UserId");

            // MaterialIds dizisini eklemek için döngü kullanıyoruz
            foreach (var materialId in createRecipeDto.MaterialId)
            {
                formData.Add(new StringContent(materialId.ToString()), "MaterialIds");
            }

            var responseMessage = await client.PostAsync("https://localhost:7092/api/Recipe", formData);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Recipe");

            }
            return View();
        }
    }
}
