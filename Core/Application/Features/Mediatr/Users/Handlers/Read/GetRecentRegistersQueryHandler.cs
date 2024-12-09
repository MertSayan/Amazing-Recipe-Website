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
    public class GetRecentRegistersQueryHandler : IRequestHandler<GetRecentRegistersQuery, List<GetRecentRegistersQueryResult>>
    {
        private readonly IUserRepository _repository;

        public GetRecentRegistersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRecentRegistersQueryResult>> Handle(GetRecentRegistersQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetRecentRegisters();
            return values.Select(x=> new GetRecentRegistersQueryResult
            {
                Name = x.Name,
                RoleName=x.Role.Name,
                Surname=x.Surname,
                CreatedDate=x.CreatedDate
            }).ToList();
        }
    }
}
