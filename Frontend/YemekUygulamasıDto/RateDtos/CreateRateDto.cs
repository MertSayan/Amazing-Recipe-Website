using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekUygulamasıDto.RateDtos
{
    public class CreateRateDto
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public int Score { get; set; }
    }
}
