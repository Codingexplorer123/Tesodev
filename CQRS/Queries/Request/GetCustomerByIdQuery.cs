using MediatR;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Queries.Request
{
    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public Guid CustomerId { get; set; }
    }
}
