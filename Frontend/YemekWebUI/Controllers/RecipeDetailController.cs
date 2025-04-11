using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using YemekUygulamasıDto.RateDtos;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı,Admin")]
    public class RecipeDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration; // IConfiguration'ı tanımlayın

        public RecipeDetailController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public IActionResult Index(int recipeId)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //ViewBag.UserId = userIdClaim.Value;
            ViewBag.Baslik = "Tarif Detayı";
            ViewBag.recipeId = recipeId;
            return View();
        }

        [HttpGet]
        public IActionResult Rate(int recipeId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.userId = userIdClaim.Value;
            ViewBag.recipeId = recipeId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Rate(CreateRateDto createRate)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createRate);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            //var responseMessage = await client.PostAsync("http://www.YEMEKAPI.somee.com/api/Rate", content);
            //var responseMessage = await client.PostAsync("https://localhost:7092/api/Rate", content);

            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.PostAsync($"{apiBaseUrl}/api/Rate", content);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Recipe");
            }

            return View();
        }
    }
}
