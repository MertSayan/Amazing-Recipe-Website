using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
    public class _AllRecipeComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public _AllRecipeComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int pageNumber,int pageSize)
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"http://www.YEMEKAPI.somee.com/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
            //var responseMessage = await client.GetAsync($"https://localhost:7092/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
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
