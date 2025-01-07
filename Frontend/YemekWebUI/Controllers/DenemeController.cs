//using Application.Dtos;
//using Application.Interfaces.RecipeInterface;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Persistence.Context;
//using System.Text;
//using YemekUygulamasıDto.RecipeDtos;

//namespace YemekWebUI.Controllers
//{
//    public class DenemeController : Controller
//    {
//        private readonly IRecipeRepository _recipeRepository;
//        private readonly YemekContext _context;
//        private readonly IHttpClientFactory _httpClientFactory;

//        public DenemeController(IRecipeRepository recipeRepository, YemekContext context, IHttpClientFactory httpClientFactory)
//        {
//            _recipeRepository = recipeRepository;
//            _context = context;
//            _httpClientFactory = httpClientFactory;
//        }



//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> RecipeListele(RecipeListeleInput input)
//        {
//            var client=_httpClientFactory.CreateClient();
//            var jsonData=JsonConvert.SerializeObject(input);
//            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
//            var responseMessage = await client.PostAsync("https://localhost:7092/api/Recipe/RecipeJqueryTable", content);
//            if(responseMessage.IsSuccessStatusCode)
//            {
//                var responseContent = await responseMessage.Content.ReadAsStringAsync();
//                var data = JsonConvert.DeserializeObject<RecipeResponse>(responseContent);

//                return Json(new
//                {
//                    draw = input.Draw,
//                    recordsTotal = data.RecordsTotal, // Toplam Kayıt Sayısı
//                    recordsFiltered = data.RecordsFiltered, // Filtrelenmiş Kayıt Sayısı
//                    data = data.Data // Gösterilecek Veri
//                });
//            }
           
//          return View();

//        }
//        //[HttpPost]
//        //public PagedListDto<ResultAllRecipeForAdminDto> GetRecipes(RecipeListeleInput input)
//        //{

//        //    var parameters = Request.Form.ToList();

//        //    var recipes = _context.Recipes
//        //        .OrderBy(x => x.Title)
//        //        .Include(x => x.Category)
//        //        .Include(x => x.User)
//        //        .AsQueryable();

//        //    var totalRecords = recipes.Count();

//        //    recipes = recipes
//        //        .WhereIf(!string.IsNullOrEmpty(input.Title), x => x.Title.ToLower().Contains(input.Title.ToLower()))
//        //        .WhereIf(!string.IsNullOrEmpty(input.CategoryName), x => x.Category.Name.ToLower().Contains(input.CategoryName.ToLower()))
//        //        .WhereIf(!string.IsNullOrEmpty(input.UserName), x => x.User.Name.ToLower().Contains(input.UserName.ToLower()))
//        //        .WhereIf(input.Search is not null &&
//        //           !string.IsNullOrEmpty(input.Search.Value),
//        //           x => x.User.Name.ToLower().Contains(input.Search.Value.ToLower())
//        //           || x.Title.ToLower().Contains(input.Search.Value.ToLower())
//        //           || x.Category.Name.ToLower().Contains(input.Search.Value.ToLower())
//        //           );


//        //    var filtrelenmisKayitSayisi = recipes.Count();
//        //    var sonuc = recipes
//        //        .Skip(input.Start)
//        //        .Take(input.Length)
//        //        .Select(x => new ResultAllRecipeForAdminDto
//        //        {
//        //            Title = x.Title,
//        //            CategoryName = x.Category.Name,
//        //            Description = x.Description,
//        //            RecipeId = x.RecipeID,
//        //            RecipeImageUrl = x.RecipeImageUrl,
//        //            Username=x.User.Name
//        //        })
//        //        .ToList();
//        //    return new PagedListDto<ResultAllRecipeForAdminDto>
//        //    {
//        //        Data = sonuc,
//        //        Draw = input.Draw,
//        //        RecordsTotal = totalRecords,
//        //        RecordsFiltered =filtrelenmisKayitSayisi
//        //    };

//        //}
//    }
//}
