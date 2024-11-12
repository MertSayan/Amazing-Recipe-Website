using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.CategoryDtos;
using YemekUygulamasıDto.MaterialDtos;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
	public class _AddRecipeGetMaterialComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AddRecipeGetMaterialComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7092/api/Material");
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
