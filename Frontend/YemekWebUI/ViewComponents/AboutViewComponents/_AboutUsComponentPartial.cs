using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YemekUygulamasıDto.AboutDtos;

namespace YemekWebUI.ViewComponents.AboutViewComponents
{

    public class _AboutUsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration; // IConfiguration'ı tanımlayın


        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7092/api/About");

            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/About");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
