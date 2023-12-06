using MediatR;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Queries.Request
{
    public class GetAllOrdersQuery: IRequest<Order>
    {
        
    }
}
