using Mapster;
using MediatR;
using Order.Application.Cqrs.Queries.DetailQueries;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.DetailHandlers
{
    public class DetailDetailQueryHandler : IRequestHandler<DetailDetailQueryRequest, DetailDetailQueryResponse>
    {
        private readonly IDetailRepository detailRepository;
        public DetailDetailQueryHandler(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public async Task<DetailDetailQueryResponse> Handle(DetailDetailQueryRequest detailDetailQueryRequest, CancellationToken cancellationToken)
            => (await detailRepository.GetFirstOrDefaultAsync(detail => detail.Id == detailDetailQueryRequest.Id)).Adapt<DetailDetailQueryResponse>();
    }
}