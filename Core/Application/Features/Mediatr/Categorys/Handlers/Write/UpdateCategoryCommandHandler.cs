using Application.Constants;
using Application.Features.Mediatr.Categorys.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categorys.Handlers.Write
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.CategoryId);
            if (value != null)
            {
                value.Name = request.Name;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Category>.EntityNotFound);
            }
        }
    }
}
