using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
    {
        private readonly TesodevDbContext _dbContext;
        public GetOrderByIdQueryHandler(TesodevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.Include(t=>t.Product).FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (order == null)
            {
                return null;
            }
            return new GetOrderByIdQueryResponse
            {
                CustomerId = order.CustomerId,
                Quantity = order.Quantity,
                Price = order.Price,
                Status  = order.Status,
                ProductId = order.ProductId,
                ImageUrl = order.Product.ImageUrl,
                Name = order.Product.Name

            };
        }
    }
}
