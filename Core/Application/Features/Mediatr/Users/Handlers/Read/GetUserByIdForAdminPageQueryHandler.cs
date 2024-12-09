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
    public class GetUserByIdForAdminPageQueryHandler : IRequestHandler<GetUserByIdForAdminPageQuery, GetUserByIdForAdminPageQueryResult>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdForAdminPageQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdForAdminPageQueryResult> Handle(GetUserByIdForAdminPageQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByUserWithOutPassword(request.Id);
            if(value!=null)
            {
                return new GetUserByIdForAdminPageQueryResult
                {
                    BirthDate = value.BirthDate,
                    Email = value.Email,
                    Name = value.Name,
                    Phone = value.Phone,
                    Surname = value.Surname,
                    UserId = value.UserId,
                };
            }
            return null;
        }
    }
}
