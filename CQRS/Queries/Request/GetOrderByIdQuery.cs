using MediatR;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Queries.Request
{
    public class GetOrderByIdQuery: IRequest<Order>
    {
        public Guid OrderId { get; set; }
    }
}
