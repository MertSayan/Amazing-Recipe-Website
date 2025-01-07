using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RateDtos;

namespace YemekWebUI.ViewComponents.RecipeDetailViewComponents
{
    public class _RecipeAvarageScoreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RecipeAvarageScoreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/Rate/GetTotalRateValueByRecipeId?recipeId="+id);
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
