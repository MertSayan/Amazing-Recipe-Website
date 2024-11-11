using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
    public class _AllRecipeComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AllRecipeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/Recipe");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAllRecipeDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
