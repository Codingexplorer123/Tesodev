using MediatR;
using TesodevCase.CQRS.Commands.Response;

namespace TesodevCase.CQRS.Commands.Request
{
    public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
