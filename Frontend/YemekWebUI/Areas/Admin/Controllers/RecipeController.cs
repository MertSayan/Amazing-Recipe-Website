using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Text;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Recipe")]
    [Authorize(Roles = "Admin")]
    public class RecipeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public RecipeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [Route("Index")]
        public async  Task<IActionResult> Index(int pageNumber=1,int pageSize=3)
        {
            var client=_httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7092/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/Recipe/GetPagedRecipe?pageNumber={pageNumber}&pageSize={pageSize}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllRecipeForAdminDto>>(jsonData);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                return View(values);
            }
            return View();
        }

        [Route("RemoveRecipe/{id}")]
        public async Task<IActionResult> RemoveRecipe(int id)
        {
            var client =_httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:7092/api/Recipe?id=" + id);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.DeleteAsync($"{apiBaseUrl}/api/Recipe?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DataTableIndex", "Recipe", new {area="Admin"});
            }
            return View();
        }

        [Route("DataTableIndex")]
        [HttpGet]
        public IActionResult DataTableIndex()
        {
            return View();
        }

        [Route("DataTable")]
        [HttpPost]
        public async Task<IActionResult> DataTable(RecipeListeleInput input)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(input);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7092/api/Recipe/RecipeJqueryTable", content);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.PostAsync($"{apiBaseUrl}/api/Recipe/RecipeJqueryTable", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<RecipeResponse>(responseContent);

                return Json(new
                {
                    draw = input.Draw,
                    recordsTotal = data.RecordsTotal, // Toplam Kayıt Sayısı
                    recordsFiltered = data.RecordsFiltered, // Filtrelenmiş Kayıt Sayısı
                    data = data.Data // Gösterilecek Veri
                });
            }

            return View();

        }

    }
}
