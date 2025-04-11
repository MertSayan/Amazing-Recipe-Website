using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.HomeViewComponents
{
    public class _RecipeAreaComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration; // IConfiguration'ı tanımlayın
        public _RecipeAreaComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("http://YEMEKAPI.somee.com/api/Recipe/TopRatedRecipes");
        //var responseMessage = await client.GetAsync("https://localhost:7092/api/Recipe/TopRatedRecipes");
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Recipe/TopRatedRecipes?Count=3");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<RecipeAreaDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
