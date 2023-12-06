using MediatR;

namespace TesodevCase.CQRS.Commands.Request
{
    public class DeleteCustomerCommand: IRequest
    {
        public Guid CustomerId { get; set; }
    }
}
