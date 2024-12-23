using Azure.Core;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using YemekUygulamasıDto.RecipeDtos;
using YemekUygulamasıDto.RegisterDtos;

namespace YemekWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {

            var client = _httpClientFactory.CreateClient();

            // Form-data içeriği oluştur
            var formData = new MultipartFormDataContent();

            // createRegisterDto içindeki her alanı form-data içine ekleyin
            formData.Add(new StringContent(createRegisterDto.Name), "Name");
            formData.Add(new StringContent(createRegisterDto.Surname), "Surname");
            formData.Add(new StringContent(createRegisterDto.Email), "Email");
            formData.Add(new StringContent(createRegisterDto.Password), "Password");
            formData.Add(new StringContent(createRegisterDto.Phone), "Phone");
            formData.Add(new StringContent(createRegisterDto.BirthDate.ToString("dd-MM-yyyy")), "BirthDate");

            // Resim dosyasını form-data içerisine ekleyin
            if (createRegisterDto.UserImageUrl != null)
            {
                var fileStream = createRegisterDto.UserImageUrl.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(createRegisterDto.UserImageUrl.ContentType);
                formData.Add(fileContent, "UserImageUrl", createRegisterDto.UserImageUrl.FileName); // API'deki ile aynı ismi kullanın
            }

            // API'ye POST isteğini gönderin
            var responseMessage = await client.PostAsync("https://localhost:7092/api/User", formData);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("~/");
            }

            return View();
        
        }

    }
}
