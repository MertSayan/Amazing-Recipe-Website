using Microsoft.AspNetCore.Mvc;

namespace YemekWebUI.ViewComponents.RecipeViewComponents
{
	public class _AddRecipeComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
