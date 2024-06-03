using Mapster;
using MediatR;
using Order.Application.Cqrs.Queries.DetailQueries;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.DetailHandlers
{
    public class DetailListQueryHandler : IRequestHandler<DetailListQueryRequest, IEnumerable<DetailListQueryResponse>>
    {
        private readonly IDetailRepository detailRepository;
        public DetailListQueryHandler(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public async Task<IEnumerable<DetailListQueryResponse>> Handle(DetailListQueryRequest detailListQueryRequest, CancellationToken cancellationToken)
            => (await detailRepository.GetAllAsync()).Adapt<IEnumerable<DetailListQueryResponse>>();
    }
}