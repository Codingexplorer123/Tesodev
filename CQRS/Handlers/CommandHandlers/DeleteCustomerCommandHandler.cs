using MediatR;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
    {
        private readonly TesodevDbContext _dbContext;
        public DeleteCustomerCommandHandler(TesodevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Customer deleteCustomer = _dbContext.Customers.FirstOrDefault(p=>p.Id == request.Id);
            _dbContext.Customers.Remove(deleteCustomer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerCommandResponse()
            {
                IsSuccess = true,
            };
        }
    }
}
