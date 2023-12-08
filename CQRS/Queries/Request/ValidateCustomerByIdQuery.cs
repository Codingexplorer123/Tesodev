using MediatR;
using TesodevCase.CQRS.Queries.Response;

namespace TesodevCase.CQRS.Queries.Request
{
    public class ValidateCustomerByIdQuery : IRequest<ValidateCustomerByIdResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
