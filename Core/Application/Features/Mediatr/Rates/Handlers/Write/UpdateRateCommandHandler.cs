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
    public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand>
    {
        private readonly IRepository<Rate> _repository;

        public UpdateRateCommandHandler(IRepository<Rate> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.RateId);
            if (value != null)
            {
                value.Score = request.Score;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Rate>.EntityNotFound);
            }
        }
    }
}
