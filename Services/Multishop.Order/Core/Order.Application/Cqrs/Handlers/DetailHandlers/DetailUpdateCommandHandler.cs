using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.DetailCommands;
using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Concrete;

namespace Order.Application.Cqrs.Handlers.DetailHandlers
{
    public class DetailUpdateCommandHandler : IRequestHandler<DetailUpdateCommandRequest, bool>
    {
        private readonly IDetailRepository detailRepository;
        public DetailUpdateCommandHandler(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public async Task<bool> Handle(DetailUpdateCommandRequest detailUpdateCommandRequest, CancellationToken cancellationToken)
            => await detailRepository.UpdateAsync(detailUpdateCommandRequest.Adapt<Detail>());
    }
}