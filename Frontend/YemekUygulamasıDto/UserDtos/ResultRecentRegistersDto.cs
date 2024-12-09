using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekUygulamasıDto.UserDtos
{
    public class ResultRecentRegistersDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RoleName { get; set; }       
        public string CreatedDate { get; set; }
    }
}
