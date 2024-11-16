using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.RecipeDetailViewComponents
{
    public class _RecipeDetailComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RecipeDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/Recipe/RecipeById?id="+id);
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
