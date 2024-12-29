using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.Controllers
{
    [Authorize(Roles = "Kullanıcı")]

    public class RecipeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RecipeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.Baslik = "Tarifler";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddRecipe()
        {
            ViewBag.Baslik = "Tarif Ekle";
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            ViewBag.userId = userIdClaim.Value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRecipe(CreateRecipeDto createRecipeDto)
        {
			

			var client = _httpClientFactory.CreateClient();
            var formData = new MultipartFormDataContent();

            // Recipe alanlarını form-data'ya ekle
            formData.Add(new StringContent(createRecipeDto.Title), "Title");
            formData.Add(new StringContent(createRecipeDto.Description), "Description");
            formData.Add(new StringContent(createRecipeDto.CategoryId.ToString()), "CategoryId");
            formData.Add(new StringContent(createRecipeDto.UserId.ToString()), "UserId");

            // Resim dosyasını form-data'ya ekle
            if (createRecipeDto.RecipeImageUrl != null)
            {
                var fileStream = createRecipeDto.RecipeImageUrl.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(createRecipeDto.RecipeImageUrl.ContentType);
                formData.Add(fileContent, "RecipeImage", createRecipeDto.RecipeImageUrl.FileName);
            }

            // MaterialId listesini form-data'ya ekle
            if (createRecipeDto.MaterialId != null && createRecipeDto.MaterialId.Any())
            {
                foreach (var materialId in createRecipeDto.MaterialId)
                {
                    formData.Add(new StringContent(materialId.ToString()), "MaterialIds");
                }
            }

            // API'ye POST isteği gönder
            var responseMessage = await client.PostAsync("https://localhost:7092/api/Recipe", formData);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
