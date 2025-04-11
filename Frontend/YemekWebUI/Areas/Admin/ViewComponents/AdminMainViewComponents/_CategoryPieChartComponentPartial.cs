using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.CategoryDtos;

namespace YemekWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _CategoryPieChartComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public _CategoryPieChartComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/Category/CategoryRecipeCount");
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Category/CategoryRecipeCount");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryRecipeCountDto>>(JsonData); 
                return View(values);
            }

            return View();
        }
    }
}
