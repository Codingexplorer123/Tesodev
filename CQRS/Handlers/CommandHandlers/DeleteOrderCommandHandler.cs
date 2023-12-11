using MediatR;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.DAL.Context;
using TesodevCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly OrderDbContext _dbContext;
        public DeleteOrderCommandHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order deleteOrder = _dbContext.Orders.FirstOrDefault(p => p.Id == request.Id);
            _dbContext.Orders.Remove(deleteOrder);
            await _dbContext.SaveChangesAsync();
            return new DeleteOrderCommandResponse()
            {
                IsSuccess = true,
            };
        }
    }
}
