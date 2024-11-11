using Application.Constants;
using Application.Features.Mediatr.Abouts.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Write
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if(value != null)
            {
                await _repository.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<About>.EntityNotFound);
            }
        }
    }
}
