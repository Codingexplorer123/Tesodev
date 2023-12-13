using MediatR;
using TesodevCase.CQRS.Queries.Response;

namespace TesodevCase.CQRS.Queries.Request
{
    public class GetOrdersByCustomerIdQuery : IRequest<List<GetOrdersByCustomerIdResponse>>
    {
        public Guid CustomerId { get; set; }
    }
}
