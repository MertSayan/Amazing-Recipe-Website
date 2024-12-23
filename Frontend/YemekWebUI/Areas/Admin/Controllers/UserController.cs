using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using YemekUygulamasıDto.RegisterDtos;
using YemekUygulamasıDto.UserDtos;

namespace YemekWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7092/api/User");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllUsersForAdminPageDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7092/api/User/GetUserByIdWithOutPassword{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserForAdminDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserForAdminDto updateUserDto)
        {
            var client = _httpClientFactory.CreateClient();

            // Form-data içeriği oluştur
            var formData = new MultipartFormDataContent();

            // createRegisterDto içindeki her alanı form-data içine ekleyin
            formData.Add(new StringContent(updateUserDto.UserId.ToString()), "UserId");
            formData.Add(new StringContent(updateUserDto.Name), "Name");
            formData.Add(new StringContent(updateUserDto.Surname), "Surname");
            formData.Add(new StringContent(updateUserDto.Email), "Email");
            formData.Add(new StringContent(updateUserDto.Phone), "Phone");
            formData.Add(new StringContent(updateUserDto.BirthDate.ToString("yyyy-MM-dd")), "BirthDate");

            // Resim dosyasını form-data içerisine ekleyin
            if (updateUserDto.UserImageUrl != null)
            {
                var fileStream = updateUserDto.UserImageUrl.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(updateUserDto.UserImageUrl.ContentType);
                formData.Add(fileContent, "UserImageUrl", updateUserDto.UserImageUrl.FileName); // API'deki ile aynı ismi kullanın
            }

            var responseMessage = await client.PutAsync("https://localhost:7092/api/User",formData);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User", new {area="Admin"});
            }

            return View();
        }

        
        [HttpGet]
        [Route("CreateUser")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserForAdminDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            // Form-data içeriği oluştur
            var formData = new MultipartFormDataContent();

            // createRegisterDto içindeki her alanı form-data içine ekleyin
            formData.Add(new StringContent(dto.Name), "Name");
            formData.Add(new StringContent(dto.Surname), "Surname");
            formData.Add(new StringContent(dto.Email), "Email");
            formData.Add(new StringContent(dto.Password), "Password");
            formData.Add(new StringContent(dto.Phone), "Phone");
            formData.Add(new StringContent(dto.BirthDate.ToString("dd-MM-yyyy")), "BirthDate");

            if (dto.UserImageUrl != null)
            {
                var fileStream = dto.UserImageUrl.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(dto.UserImageUrl.ContentType);
                formData.Add(fileContent, "UserImageUrl", dto.UserImageUrl.FileName); // API'deki ile aynı ismi kullanın
            }

            var responseMessage = await client.PostAsync("https://localhost:7092/api/User", formData);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User", new {area="Admin"});
            }

            return View();
        }


        [Route("RemoveUser/{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7092/api/User?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            return View();
        }
    }
}
