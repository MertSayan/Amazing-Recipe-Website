using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.CategoryDtos;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
	public class _AddRecipeGetCategoryComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AddRecipeGetCategoryComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7092/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultAllCategoryDto>>(jsonData);
				return View(value);
			}
			return View();
		}
	}
}
