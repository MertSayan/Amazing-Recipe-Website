using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.ProfileViewComponents
{
    public class _ProfileOwnerRecipesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public _ProfileOwnerRecipesComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.userId = id;
            var client=_httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"http://www.YEMEKAPI.somee.com/api/Recipe/GetRecipeByUserIdQuery?id=" + id);
            //var responseMessage = await client.GetAsync($"https://localhost:7092/api/Recipe/GetRecipeByUserIdQuery?id=" + id);

            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Recipe/GetRecipeByUserIdQuery?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultRecipeProfileDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
