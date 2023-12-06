using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.DAL.Context;


namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly TesodevDbContext _dbContext;
        public UpdateOrderCommandHandler(TesodevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.
                        Include(t => t.Address).Include(t => t.Product).
                        Include(t => t.Customer).FirstOrDefaultAsync(f=>f.Id == command.OrderId , cancellationToken);
            
            if(order == null)
            {
                return Unit.Value;
            }
            order.Quantity = command.Quantity;
            order.Price = command.Price;
            order.Status = command.Status;
            order.UpdatedAt = DateTime.Now;

            if(order.Product != null)
            {
                order.Product.Name = command.ProductName;
                order.Product.ImageUrl = command.ProductImageUrl;
            }
            
            if(order.Address != null)
            {
                order.Address.AddressLine = command.AddressLine;
                order.Address.City = command.City;
                order.Address.Country = command.Country;
                order.Address.CityCode = command.CityCode;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }

    }
}
