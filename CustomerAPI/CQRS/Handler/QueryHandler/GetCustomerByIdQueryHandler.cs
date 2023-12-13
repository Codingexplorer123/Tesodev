using MediatR;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.DAL.Context;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
    {
        private readonly CustomerDbContext _dbContext;
        public GetCustomerByIdQueryHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = _dbContext.Customers.FirstOrDefault(p => p.Id == request.Id);
            if (customer == null)
            {
                return null;
            }

            return new GetCustomerByIdQueryResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };
        }



    }
}
