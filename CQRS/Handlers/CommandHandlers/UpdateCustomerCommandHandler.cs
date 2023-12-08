using MediatR;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly TesodevDbContext _dbContext;
        public UpdateCustomerCommandHandler(TesodevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers.FindAsync(request.Id);

            if (customer == null)
            {
                return new UpdateCustomerCommandResponse()
                {
                    IsSuccess = false,
                };
            }
            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.UpdatedAt = DateTime.Now;
            customer.Address = request.Address;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateCustomerCommandResponse()
            {
                IsSuccess = true,
            };

        }
    }
}
