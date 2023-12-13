using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, List<Customer>>
    {
        private readonly CustomerDbContext _dbContext;

        public async Task<List<Customer>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _dbContext.Customers.ToListAsync(cancellationToken);
            return customers;
        }
    }
}
