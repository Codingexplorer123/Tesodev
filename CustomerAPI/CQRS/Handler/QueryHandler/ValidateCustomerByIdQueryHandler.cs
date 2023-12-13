using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.DAL.Context;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class ValidateCustomerByIdQueryHandler : IRequestHandler<ValidateCustomerByIdQuery,ValidateCustomerByIdResponse>
    {
        private readonly CustomerDbContext _dbContext;
        public ValidateCustomerByIdQueryHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ValidateCustomerByIdResponse> Handle(ValidateCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var CustomerExists = await _dbContext.Customers.AnyAsync(f=>f.Id == request.CustomerId, cancellationToken);
            
            if (CustomerExists == true)
            {
                return new ValidateCustomerByIdResponse
                {
                    IsAvailable = true
                };
                
            }
            else
            {
                return new ValidateCustomerByIdResponse
                {
                    IsAvailable = false
                };
            }
        }
    }
}
