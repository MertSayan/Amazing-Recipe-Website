using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RateDtos;

namespace YemekWebUI.ViewComponents.RecipeDetailViewComponents
{
    public class _RecipeAvarageScoreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _RecipeAvarageScoreComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://www.YEMEKAPI.somee.com/api/Rate/GetTotalRateValueByRecipeId?recipeId=" + id);
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/Rate/GetTotalRateValueByRecipeId?recipeId=" + id);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Rate/GetTotalRateValueByRecipeId?recipeId=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<AvarageScoreDto>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
