using TesodevCase.DAL.Context;

using TesodevCase.Entities;
using TesodevCase.CQRS.Commands.Request;
using MediatR;
using TesodevCase.CQRS.Commands.Response;

namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly OrderDbContext _dbContext;


        public CreateOrderCommandHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            Order order = new Order()
            {
                Id = id,
                CustomerId = request.CustomerId,
                Quantity = request.Quantity,
                Price = request.Price,
                Status = request.Status,
                Address = request.Address,
                Product = request.Product,
                CreatedAt = DateTime.UtcNow
            };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderCommandResponse()
            {
                Id = id,
            };
        }
    }
}
