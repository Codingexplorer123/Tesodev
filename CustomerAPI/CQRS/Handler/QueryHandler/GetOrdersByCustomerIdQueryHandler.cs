using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;



namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, List<GetOrdersByCustomerIdResponse>>
    {
        private readonly CustomerDbContext _dbContext;
        public GetOrdersByCustomerIdQueryHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GetOrdersByCustomerIdResponse>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders.Where(p => p.CustomerId == request.CustomerId)
                                                .Select(s => new GetOrdersByCustomerIdResponse
                                                 {
                                                     Id = s.Id,
                                                     Quantity = s.Quantity,
                                                     Price = s.Price,
                                                     Status = s.Status,
                                                     CreatedAt = s.CreatedAt,
                                                     UpdatedAt = s.UpdatedAt

                                                 }).ToListAsync(cancellationToken);
            return orders;
        }
    }
}
