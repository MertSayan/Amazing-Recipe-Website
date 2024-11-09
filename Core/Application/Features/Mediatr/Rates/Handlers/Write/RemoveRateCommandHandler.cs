using Application.Constants;
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
    public class RemoveRateCommandHandler : IRequestHandler<RemoveRateCommand>
    {
        private readonly IRepository<Rate> _repository;

        public RemoveRateCommandHandler(IRepository<Rate> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRateCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<Rate>.EntityNotFound);
            }
        }
    }
}
