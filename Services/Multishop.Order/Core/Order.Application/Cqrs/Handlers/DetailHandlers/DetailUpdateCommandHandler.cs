using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.DetailCommands;
using Order.Application.Repositories.Abstract;

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
        {
            var detail = await detailRepository.GetFirstOrDefaultAsync(detail => detail.Id == detailUpdateCommandRequest.Id);
            if (detail is null) return false;

            return await detailRepository.UpdateAsync(detailUpdateCommandRequest.Adapt(detail));
        }
    }
}