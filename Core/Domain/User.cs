using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User:Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? UserImageUrl { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Rate> RateList { get; set; }
    }
}
