using TesodevCase.DAL.Context;

using TesodevCase.Entities;
using TesodevCase.CQRS.Commands.Request;
using MediatR;

namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly TesodevDbContext _dbContext;
        

        public CreateOrderCommandHandler(TesodevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = command.CustomerId,
                Quantity = command.Quantity,
                Price = command.Price,
                Status = command.Status,
                AddressId = command.AddressId,
                ProductId = command.ProductId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
