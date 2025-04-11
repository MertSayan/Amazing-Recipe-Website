using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.RecipeDetailViewComponents
{
    public class _RecipeDetailComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _RecipeDetailComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.recipeId = id;
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://www.YEMEKAPI.somee.com/api/Recipe/RecipeById?id=" + id);
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/Recipe/RecipeById?id="+id);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Recipe/RecipeById?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ResultRecipeByIdDto>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
