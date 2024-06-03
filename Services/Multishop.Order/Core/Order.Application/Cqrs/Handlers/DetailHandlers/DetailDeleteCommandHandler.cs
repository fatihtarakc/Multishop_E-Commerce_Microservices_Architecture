using MediatR;
using Order.Application.Cqrs.Commands.DetailCommands;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.DetailHandlers
{
    public class DetailDeleteCommandHandler : IRequestHandler<DetailDeleteCommandRequest, bool>
    {
        private readonly IDetailRepository detailRepository;
        public DetailDeleteCommandHandler(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public async Task<bool> Handle(DetailDeleteCommandRequest detailDeleteCommandRequest, CancellationToken cancellationToken)
            => await detailRepository.DeleteAsync(detailDeleteCommandRequest.Id);
    }
}