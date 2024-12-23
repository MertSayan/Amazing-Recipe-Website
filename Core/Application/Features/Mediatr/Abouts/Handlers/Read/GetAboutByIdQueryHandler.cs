using Application.Features.Mediatr.Abouts.Queries;
using Application.Features.Mediatr.Abouts.Results;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Read
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if(value!= null)
            {
                return new GetAboutByIdQueryResult
                {
                    AboutId=value.AboutId,
                    Description=value.Description,
                };
            }
            return null;
        }
    }
}
