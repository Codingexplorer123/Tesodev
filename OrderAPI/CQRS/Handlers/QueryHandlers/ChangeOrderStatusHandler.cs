using MediatR;
using Microsoft.EntityFrameworkCore;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.DAL.Context;

namespace TesodevCase.CQRS.Handlers.QueryHandlers
{
    public class ChangeOrderStatusHandler : IRequestHandler<ChangeOrderStatusQueryRequest, bool>
    {
        private readonly OrderDbContext _dbContext;
        public ChangeOrderStatusHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(ChangeOrderStatusQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(f=>f.Id == request.Id, cancellationToken);
            if (order == null)
            {
              return false;
            }

            order.Status = request.Status;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
           
           
        }
    }
}
