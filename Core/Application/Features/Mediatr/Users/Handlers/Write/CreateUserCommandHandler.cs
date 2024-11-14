using Application.Enums;
using Application.Features.Mediatr.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Write
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string photoPath = null;
            if (request.UserImageUrl != null && request.UserImageUrl.Length > 0)
            {
                var uploadsFolderPath = Path.Combine("C:\\csharpprojeler\\YemekUygulaması\\Frontend\\YemekWebUI", "wwwroot", "users");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileExtension = Path.GetExtension(request.UserImageUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}_{fileExtension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.UserImageUrl.CopyToAsync(fileStream);
                }

                photoPath = $"/users/{uniqueFileName}";

                
            }
            User user = _mapper.Map<User>(request);
            user.UserImageUrl = photoPath;
            await _repository.CreateAsync(user);
        }
    }
}
