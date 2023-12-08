using MediatR;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly TesodevDbContext _dbContext;
        public CreateCustomerCommandHandler(TesodevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            _dbContext.Customers.Add(new Customer
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                CreatedAt = DateTime.UtcNow,
            });
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateCustomerCommandResponse
            {
                Id = id,
            };
            
            
        }
    }
}
