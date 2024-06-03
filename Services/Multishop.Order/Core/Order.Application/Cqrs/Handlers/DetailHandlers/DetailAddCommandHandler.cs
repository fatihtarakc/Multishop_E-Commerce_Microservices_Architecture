using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.DetailCommands;
using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Concrete;

namespace Order.Application.Cqrs.Handlers.DetailHandlers
{
    public class DetailAddCommandHandler : IRequestHandler<DetailAddCommandRequest, bool>
    {
        private readonly IDetailRepository detailRepository;
        public DetailAddCommandHandler(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public async Task<bool> Handle(DetailAddCommandRequest detailAddCommandRequest, CancellationToken cancellationToken)
            => await detailRepository.AddAsync(detailAddCommandRequest.Adapt<Detail>());
    }
}