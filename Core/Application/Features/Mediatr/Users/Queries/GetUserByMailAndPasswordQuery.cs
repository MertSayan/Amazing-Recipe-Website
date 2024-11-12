using Application.Features.Mediatr.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Queries
{
    public class GetUserByMailAndPasswordQuery:IRequest<GetUserByMailAndPasswordQueryResult>
    {
        public GetUserByMailAndPasswordQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
