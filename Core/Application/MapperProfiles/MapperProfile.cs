using Application.Enums;
using Application.Features.Mediatr.Users.Commands;
using Application.Features.Mediatr.Users.Results;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MapperProfiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap()
               .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Rol.Kullanıcı));
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User,GetUserQueryResult>().ReverseMap();
            CreateMap<User,GetUserByIdQueryResult>().ReverseMap();

            CreateMap<GetUserByMailAndPasswordQueryResult, User>().ReverseMap()
               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

        }
    }
}
