using MediatR;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.DAL.Context;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest,GetCustomerByIdQueryResponse>
    {
        private readonly TesodevDbContext _dbContext;
        public GetCustomerByIdQueryHandler(TesodevDbContext dbContext)
        {
            _dbContext= dbContext;
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
