using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        // User sınıfı
        public class User   
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            // Örnek User verileri
            var users = new List<User>
            {
                new User { Id = 1, Name = "Ali", Email = "Ali@gmail.com" },
                new User { Id = 2, Name = "Veli", Email = "Veli@gmail.com" },
                new User { Id = 3, Name = "Barıs", Email = "Barıs@gmail.com" }
            };

            return Ok(users); // JSON formatında döner
        }
    }
}
