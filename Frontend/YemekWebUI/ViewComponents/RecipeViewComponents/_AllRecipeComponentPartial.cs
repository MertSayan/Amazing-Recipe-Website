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

        public async Task<IViewComponentResult> InvokeAsync(int pageNumber,int pageSize)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7092/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAllRecipeDto>>(jsonData);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                return View(value);
            }
            
            return View();
        }
    }
}
