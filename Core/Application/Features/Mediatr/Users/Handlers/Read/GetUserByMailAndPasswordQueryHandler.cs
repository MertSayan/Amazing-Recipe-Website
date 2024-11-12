using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetUserByMailAndPasswordQueryHandler : IRequestHandler<GetUserByMailAndPasswordQuery, GetUserByMailAndPasswordQueryResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByMailAndPasswordQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByMailAndPasswordQueryResult> Handle(GetUserByMailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var value=new GetUserByMailAndPasswordQueryResult();

            var user=await _userRepository.GetByFilterAsync(x=>x.Email==request.Email && x.Password==request.Password && x.DeletedDate==null);
            if (user!=null)
            {
                value=_mapper.Map<GetUserByMailAndPasswordQueryResult>(user);
                value.IsExist = true;
            }
            else
            {
                value.IsExist=false;
            }
            return value;
        }
    }
}
