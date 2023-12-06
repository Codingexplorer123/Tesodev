using MediatR;

namespace TesodevCase.CQRS.Commands.Request
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
