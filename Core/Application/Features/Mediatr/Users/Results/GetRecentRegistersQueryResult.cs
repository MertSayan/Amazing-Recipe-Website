using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Results
{
    public class GetRecentRegistersQueryResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RoleName { get; set; }
        
        public DateTime? CreatedDate { get; set; }
    }
}
