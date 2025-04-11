using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using YemekUygulamasıDto.UserDtos;

namespace YemekWebUI.ViewComponents.ProfileViewComponents
{
    public class _ProfileInformationComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _ProfileInformationComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.userId = id;

            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"http://www.YEMEKAPI.somee.com/api/User/byId?id=" +id);
            //var responseMessage = await client.GetAsync($"https://localhost:7092/api/User/byId?id=" +id);
            var apiBaseUrl = _configuration["ApiBaseUrl"];
            var responseMessage = await client.GetAsync($"{apiBaseUrl}/api/User/byId?id=" +id);
            if(responseMessage != null)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ResultUserDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
