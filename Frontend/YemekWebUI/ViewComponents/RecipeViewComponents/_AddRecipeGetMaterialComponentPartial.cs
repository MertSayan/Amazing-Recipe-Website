using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.CategoryDtos;
using YemekUygulamasıDto.MaterialDtos;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
	public class _AddRecipeGetMaterialComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;
        public _AddRecipeGetMaterialComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://www.YEMEKAPI.somee.com/api/Material");
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/Material");
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Material");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultAllMaterialDto>>(jsonData);
				return View(value);
			}
			return View();
		}
	}

}
