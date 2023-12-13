using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<Order>>
    {
        private readonly OrderDbContext _dbContext;
        public GetAllOrderQueryHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Order>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders.ToListAsync(cancellationToken);
            return orders;
        }
    }
}
