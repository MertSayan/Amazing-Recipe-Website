using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Results
{
    public class GetUserByMailAndPasswordQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? UserImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RoleName { get; set; }

        public bool IsExist { get; set; }
    }
}
