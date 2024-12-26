using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetPagedUserQueryHandler : IRequestHandler<GetPagedUserQuery, List<GetPagedUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetPagedUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetPagedUserQueryResult>> Handle(GetPagedUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetPagedUserAsync(request.PageNumber, request.PageSize);
            return users.Select(x => new GetPagedUserQueryResult
            {
                BirthDate = x.BirthDate,
                Email = x.Email,
                Name = x.Name,
                Phone=x.Phone,
                Surname = x.Surname,
                UserId = x.UserId,  
                UserImageUrl=x.UserImageUrl
            }).ToList();
        }
    }
}
