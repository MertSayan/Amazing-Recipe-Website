using Application.Features.Mediatr.Rates.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Handlers.Write
{
    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand>
    {
        private readonly IRepository<Rate> _repository;

        public CreateRateCommandHandler(IRepository<Rate> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Rate
            {
                RecipeId = request.RecipeId,
                UserId = request.UserId,
                Score = request.Score,
            });
        }
    }
}
