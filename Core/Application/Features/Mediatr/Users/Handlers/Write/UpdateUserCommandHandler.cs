using Application.Constants;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            string photoPath = null;
            if (request.UserImageUrl != null && request.UserImageUrl.Length > 0)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "users");
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

            var value = await _repository.GetByIdAsync(request.UserId);
            if (value != null)
            {
                value = _mapper.Map(request, value);
                value.UserImageUrl= photoPath;  
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<User>.EntityNotFound);
            }

        }
    }
}
