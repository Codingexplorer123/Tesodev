using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.DAL.Context;


namespace TesodevCase.CQRS.Handlers.CommandHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest,UpdateOrderCommandResponse>
    {
        private readonly OrderDbContext _dbContext;
        public UpdateOrderCommandHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.Include(t => t.Product).Include(t => t.Address)
                                               .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            
            if(order == null)
            {
                return new UpdateOrderCommandResponse()
                {
                    IsSuccess = false
                };
            }
            order.CustomerId = request.CustomerId;
            order.Quantity = request.Quantity;
            order.Price = request.Price;
            order.Status = request.Status;
            order.UpdatedAt = DateTime.UtcNow;

            if(order.Product != null)
            {
                order.Product.Name = request.ProductName;
                order.Product.ImageUrl = request.ProductImageUrl;
            }
            
            if(order.Address != null)
            {
                order.Address.AddressLine = request.AddressLine;
                order.Address.City = request.City;
                order.Address.Country = request.Country;
                order.Address.CityCode = request.CityCode;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateOrderCommandResponse()
            {
                IsSuccess = true
            };

        }

        
       
    }
}
