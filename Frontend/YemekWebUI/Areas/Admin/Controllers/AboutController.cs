using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Text;
using YemekUygulamasıDto.AboutDtos;

namespace YemekWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    [Authorize(Roles="Admin")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AboutController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/About");
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAboutForAdminDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client=_httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/About/ById?id="+id);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/About/ById?id="+id);

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateAboutDto);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7092/api/About",content);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.PutAsync($"{apiBaseUrl}/api/About",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
